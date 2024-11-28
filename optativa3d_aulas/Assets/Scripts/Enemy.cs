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

    private Rigidbody rb;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
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
    }
}
