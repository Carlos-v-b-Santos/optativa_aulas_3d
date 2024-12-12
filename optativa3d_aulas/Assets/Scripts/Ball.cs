using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float killHeight;
    [SerializeField] private float duration;
    [SerializeField] private Vector3 initialScale;
    [SerializeField] private Vector3 finalScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }
    void FixedUpdate()
    {
        VerifyKill();
    }

    private void VerifyKill()
    {
        if (transform.position.y < killHeight)
        {
            Kill();
        }
    }

    private void Kill()
    {
        StartCoroutine(KillScaleAnim());
        GameManager.Instance.GameOver();
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
    }
}
