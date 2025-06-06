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

    [SerializeField] private Vector3 MobileMove;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotacaoInicial = transform.rotation;
        audioSourceMove.Play();
        audioSourceMove.Pause();

        IntroMobileInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MobileMoveInput();
        //GetMoveInput();
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

            Quaternion deltaRotation = Quaternion.Euler(rotateVelocity * Time.fixedDeltaTime * move);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    private void IntroMobileInput()
    {
        Input.gyro.enabled = true;
    }

    private void MobileMoveInput()
    {
        MobileMove = GameManager.Instance.playerInputActions.Player.MoveMobile.ReadValue<Vector3>();

        Debug.Log("valor do giroscopio: " + MobileMove);

        if (move == Vector3.zero)
        {
            audioSourceMove.Pause();
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotacaoInicial, Time.deltaTime * recoverVelocity));
        }

        if (MobileMove != Vector3.zero)
        {

            if (!audioSourceMove.isPlaying) audioSourceMove.UnPause();

            Debug.Log("inclinar eixo X");
            //transform.Rotate(move.x * rotateVelocity * Time.deltaTime * Vector3.up);

            Quaternion deltaRotationD = transform.rotation;
            deltaRotationD[0] = Quaternion.Euler(rotateVelocity * Time.fixedDeltaTime * MobileMove).y;
            deltaRotationD[1] = Quaternion.Euler(rotateVelocity * Time.fixedDeltaTime * MobileMove).x;
            deltaRotationD[2] = -Quaternion.Euler(rotateVelocity * Time.fixedDeltaTime * MobileMove).z;
            deltaRotationD[3] = 1.0f;

            Quaternion deltaRotation = Quaternion.Euler(rotateVelocity * Time.fixedDeltaTime * MobileMove);
            
            Debug.Log("delta rotation:" + deltaRotation);
            Debug.Log("delta rotation dividido:" + deltaRotationD);
            rb.MoveRotation(rb.rotation * deltaRotationD);
        }
    }
}
