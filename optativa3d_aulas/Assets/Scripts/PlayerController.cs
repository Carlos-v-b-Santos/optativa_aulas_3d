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
    [SerializeField] private float powerMass;
    [SerializeField] private float attackForce;
    
    [SerializeField] private GameObject stabilizer;

    Rigidbody rb;
    
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.AddForce(stabilizer.transform.right * speed);

        }
        else if (move.x > 0)
        {
            rb.AddForce(-stabilizer.transform.right * speed);
        }

        if (move.y < 0 ) 
        {
            
            rb.AddForce(stabilizer.transform.forward * speed);
        }
        else if(move.y > 0) 
        {
            
            rb.AddForce(-stabilizer.transform.forward * speed);
        }

        
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("powerMass apertada");
        rb.mass = powerMass;
    }
    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Player.Attack.performed += Attack;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Player.Attack.performed -= Attack;
    }
}
