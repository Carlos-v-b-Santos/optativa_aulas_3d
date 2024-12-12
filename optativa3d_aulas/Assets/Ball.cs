using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float killHeight;
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
        GameManager.Instance.GameOver();
    }
}
