using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints;
    [SerializeField] private int spawnIndex;

    [SerializeField] private int spawnPointCount;
    [SerializeField] private int spawnPointCountStep = 1;
    
    [SerializeField] private int enemySpawnQuantity;
    [SerializeField] private int enemySpawnQuatityStep = 1;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnTimeStep;
    [SerializeField] private float spawnVariation;

    [SerializeField] private float difficultyMilestone = 60;
    [SerializeField] private float difficultyStep = 60;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(IniciarSpawn());
    }

    private void Update()
    {
        if (TimeManager.Instance.time >= difficultyMilestone)
        {
            Debug.Log("Dificuldade aumentada");
            IncreaseDifficulty();
            difficultyMilestone += difficultyStep;
        }
    }

    private void IncreaseDifficulty()
    {
        int difficultyChoice = Random.Range(0, 3);

        switch (difficultyChoice)
        {
            case 0:
                if (spawnTime > minSpawnTime)
                {
                    Debug.Log("spawnTime Reduzido");
                    spawnTime -= spawnTimeStep;
                }
                goto case 1;

            case 1:
                if (spawnPointCount < spawnPoints.Length)
                {
                    Debug.Log("spawnPointCount aumentado");
                    spawnPointCount += spawnPointCountStep;
                    return;
                }
                goto case 2;

            case 2:
                Debug.Log("enemySpawnQuantity aumentado");
                enemySpawnQuantity += enemySpawnQuatityStep;
                return;
            
            default:
                Debug.Log("Erro ao gerar a escolha de incremento de dificuldade");
                break;
        }
    }

    IEnumerator IniciarSpawn()
    { 
        while (true)
        {   
            float tempoEspera = spawnTime + Random.Range(0, spawnVariation);

            if (spawnPointCount == 1)
            {
                spawnPoints[Random.Range(0, spawnPoints.Length)].Spawn(enemySpawnQuantity);
            }
            else if (spawnPointCount >= spawnPoints.Length)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].Spawn(enemySpawnQuantity);
                }
            }
            else
            {
                for(int i = 0; i < spawnPointCount; i++)
                {
                    spawnPoints[i].Spawn(enemySpawnQuantity);
                }
            }
            yield return new WaitForSeconds(tempoEspera);
        }
    }
}

        