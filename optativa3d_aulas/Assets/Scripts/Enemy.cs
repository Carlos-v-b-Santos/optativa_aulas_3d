using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float attackForce;

    [SerializeField] private float moveDelayCurrent;
    [SerializeField] private float moveDelay;

    [SerializeField] private float killHeight;

    [SerializeField] private bool isGround;
    [SerializeField] private bool isDeath;

    [SerializeField] private float duration;
    [SerializeField] private Vector3 initialScale;
    [SerializeField] private Vector3 finalScale;

    private Rigidbody rb;
    public Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
        initialScale = player.localScale;
        isDeath = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        VerifyKill();
    }

    private void VerifyKill()
    {
        if(transform.position.y < killHeight)
        {
            Kill();
        }
    }

    private void Kill()
    {
        //bug na pontuação? não é bug, é feature
        ScoreManager.Instance.IncreaseScore();
        StartCoroutine(KillScaleAnim());
    }

    private void Move()
    {
        if (!isGround) return;

        if (moveDelayCurrent >= moveDelay)
        {
            direction = (player.position - this.transform.position).normalized;
            moveDelayCurrent = 0.0f;
        }
        else
        {
            moveDelayCurrent += Time.deltaTime;
        }

        rb.AddForce(direction * speed * Time.deltaTime, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.AddForce(direction * attackForce,ForceMode.Impulse);
        }

        if(collision.gameObject.CompareTag("Cumbuca"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cumbuca"))
        {
            isGround = false;
        }
    }

    private IEnumerator KillScaleAnim()
    {
        float tempoAtual = 0f;

        while (tempoAtual < duration)
        {
            // Incrementa o tempo decorrido
            tempoAtual += Time.deltaTime;

            // Interpola entre a escala inicial e a final
            transform.localScale = Vector3.Lerp(initialScale, finalScale, tempoAtual / duration);

            yield return null; // Espera até o próximo frame
        }

        // Garante que a escala final seja exata no final
        transform.localScale = finalScale;
        
        Destroy(this.gameObject);
    }
}
