using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Quaternion rotacaoInicial;
    [SerializeField] private Quaternion rotacaoOuticial;

    [SerializeField] private float rotateVelocity;

    [SerializeField] private Vector3 move;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotacaoInicial = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveInput();
        rotacaoOuticial = transform.rotation;
    }

    private void GetMoveInput()
    {
        move = GameManager.Instance.playerInputActions.Player.Move.ReadValue<Vector3>();


        if(move == Vector3.zero)
        {
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotacaoInicial, Time.deltaTime * rotateVelocity));
        }

        if (move.x != 0f)
        {
            Debug.Log("inclinar eixo X");
            transform.Rotate(move.x * rotateVelocity * Time.deltaTime * Vector3.up);
        }
        else
        {
            
        }

        if (move.y != 0f)
        {
            Debug.Log("inclinar eixo Y");
            transform.Rotate(move.y * rotateVelocity * Time.deltaTime * Vector3.right);
        }

        if(move.z != 0f)
        {
            Debug.Log("girar eixo Z");
            transform.Rotate(move.z * rotateVelocity * Time.deltaTime * Vector3.forward);
        }
    }
}
