using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = new string("PONTOS:\n" + ScoreManager.Instance.score);
    }
}
