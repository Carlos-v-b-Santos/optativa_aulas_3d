using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private int score;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um ScoreManager");
            return;
        }
        Instance = this;
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
