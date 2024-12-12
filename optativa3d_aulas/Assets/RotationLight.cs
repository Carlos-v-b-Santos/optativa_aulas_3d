using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLight : MonoBehaviour
{
    public float translationVelocity = 10f; // Velocidade de rotação em graus por segundo

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y
        transform.Rotate(Vector3.up * translationVelocity * Time.deltaTime, Space.World);
    }
}
