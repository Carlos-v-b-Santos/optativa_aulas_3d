using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = camera.transform.position - transform.position;
        direction.y = 0;

        Quaternion directionQuaternion = Quaternion.LookRotation(direction);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, directionQuaternion, 1);
    }
}
