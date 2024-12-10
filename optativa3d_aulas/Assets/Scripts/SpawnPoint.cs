using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    
    public void Spawn()
    {
        Instantiate(enemy,this.transform);
    }
}