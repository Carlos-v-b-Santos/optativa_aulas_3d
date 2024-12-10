using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints;
    [SerializeField] private int spawnIndex;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(IniciarSpawn());
    }

    IEnumerator IniciarSpawn()
    {
        while (true)
        {

            float tempoEspera = Random.Range(minSpawnTime, maxSpawnTime);
            spawnPoints[Random.Range(0, spawnPoints.Length)].Spawn();

            yield return new WaitForSeconds(tempoEspera);
        }
    }
}
