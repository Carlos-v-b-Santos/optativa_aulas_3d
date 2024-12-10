using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainForce : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float downForce;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        rb.AddForce(Vector3.one * downForce);
    }
}
