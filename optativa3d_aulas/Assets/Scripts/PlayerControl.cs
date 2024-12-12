using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Quaternion rotacaoInicial;
    [SerializeField] private Quaternion rotacaoOuticial;

    [SerializeField] private float rotateVelocity;
    [SerializeField] private float recoverVelocity;

    [SerializeField] private Vector3 move;

    [SerializeField] private AudioSource audioSourceMove;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotacaoInicial = transform.rotation;
        audioSourceMove.Play();
        audioSourceMove.Pause();
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
            audioSourceMove.Pause();
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotacaoInicial, Time.deltaTime * recoverVelocity));
        }

        if (move != Vector3.zero)
        {
            
            if(!audioSourceMove.isPlaying) audioSourceMove.UnPause();

            Debug.Log("inclinar eixo X");
            //transform.Rotate(move.x * rotateVelocity * Time.deltaTime * Vector3.up);

            Quaternion deltaRotation = Quaternion.Euler(move * rotateVelocity * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
