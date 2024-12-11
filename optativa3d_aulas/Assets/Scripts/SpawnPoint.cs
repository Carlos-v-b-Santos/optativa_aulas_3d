using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemyGroup;
    [SerializeField] private float spawnDelay = 0.5f;
    // Start is called before the first frame update
    


    public void Spawn()
    {

        if (enemy != null)
        {
            Instantiate(enemy, this.transform.position, Quaternion.identity, enemyGroup);
        }
        else
        {
            Instantiate(enemy, this.transform);
        }
    }

    public void Spawn(int quantity)
    {
        StartCoroutine(SpawnRoutine(quantity));
    }

    IEnumerator SpawnRoutine(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
