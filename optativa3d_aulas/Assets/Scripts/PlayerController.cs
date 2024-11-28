using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float normalMass;
    [SerializeField] private float powerMass;
    
    [SerializeField] private GameObject stabilizer;
    
    [SerializeField] private float attackForce;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool attackMode;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDuration;

    Rigidbody rb;
    
    private Vector2 move;
    private InputAction attack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attack = GameManager.Instance.playerInputActions.FindAction("Attack");
        normalMass = rb.mass;
        canAttack = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveInput();
    }

    private void GetMoveInput()
    {
        move = GameManager.Instance.playerInputActions.Player.Move.ReadValue<Vector2>();
        
        if(move.x < 0 )
        {
            rb.AddForce(stabilizer.transform.right * speed,ForceMode.Acceleration);

        }
        else if (move.x > 0)
        {
            rb.AddForce(-stabilizer.transform.right * speed, ForceMode.Acceleration);
        }

        if (move.y < 0 ) 
        {
            
            rb.AddForce(stabilizer.transform.forward * speed, ForceMode.Acceleration);
        }
        else if(move.y > 0) 
        {
            
            rb.AddForce(-stabilizer.transform.forward * speed, ForceMode.Acceleration);
        }

        if(attack.IsPressed() )
        {
            if(canAttack)
            {
                StartCoroutine(AttackMode());
            }
        }
    }

    IEnumerator AttackMode()
    {
        Debug.Log("AttackMode Active");
        attackMode = true;
        rb.mass = powerMass;
        canAttack = false;

        yield return new WaitForSeconds(attackDuration);

        Debug.Log("AttackMode Desactive");
        attackMode = false;
        rb.mass = normalMass;

        yield return new WaitForSeconds(attackCooldown);

        Debug.Log("canAttack");
        canAttack = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (attackMode)
            {
                Vector3 direction = collision.gameObject.GetComponent<Enemy>().direction;

                collision.rigidbody.AddForce((-direction) * attackForce, ForceMode.Impulse);
            }
        }
    }
}
