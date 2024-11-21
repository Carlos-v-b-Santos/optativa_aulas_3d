using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject stabilizer;

    PlayerInputActions playerInputActions;
    Rigidbody rb;
    

    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();

        playerInputActions.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveInput();
    }

    private void GetMoveInput()
    {
        move = playerInputActions.Player.Move.ReadValue<Vector2>();
        
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
}
