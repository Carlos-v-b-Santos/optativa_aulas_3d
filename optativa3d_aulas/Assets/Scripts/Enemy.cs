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

    private Rigidbody rb;
    public Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
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
        ScoreManager.Instance.IncreaseScore();
        Destroy(this.gameObject);
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
}
