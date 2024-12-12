using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinalUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreRecord;
    [SerializeField] private TextMeshProUGUI timeRecord;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private string scoreRecordKey = "SCORE_RECORD";
    [SerializeField] private string timeRecordKey = "TIME_RECORD";
    [SerializeField] private string scoreKey = "SCORE_PLAYER";
    [SerializeField] private string timeKey = "TIME_PLAYER";
    void Awake()
    {
        scoreRecord.text = new string("Pontos: " + PlayerPrefs.GetInt(scoreRecordKey));
        timeRecord.text = string.Format("Tempo: {0:00}:{1:00}", Mathf.FloorToInt(PlayerPrefs.GetFloat(timeRecordKey) / 60),
        Mathf.FloorToInt(PlayerPrefs.GetFloat(timeRecordKey) % 60));

        score.text = new string("Pontos: " + PlayerPrefs.GetInt(scoreKey));
        time.text = string.Format("Tempo: {0:00}:{1:00}", Mathf.FloorToInt(PlayerPrefs.GetFloat(timeKey) / 60),
            Mathf.FloorToInt(PlayerPrefs.GetFloat(timeKey) % 60));
    }
}
