using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerInputActions playerInputActions;

    TransitionEffect transitionEffect;

    [SerializeField] private string scoreRecordKey = "SCORE_RECORD";
    [SerializeField] private string timeRecordKey = "TIME_RECORD";
    [SerializeField] private string scoreKey = "SCORE_PLAYER";
    [SerializeField] private string timeKey = "TIME_PLAYER";

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
            return;
        }
        Instance = this;

        playerInputActions = new PlayerInputActions();
        if (playerInputActions != null)
        {
            Debug.Log("playerInputActions instaciado");
        }

        playerInputActions.Enable();

        transitionEffect = FindObjectOfType<TransitionEffect>();

        transitionEffect.FadeOut();

        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        transitionEffect.FadeOut();
        Time.timeScale = 1;

    }
    public void ChanceScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void GameOver()
    {
        PauseGame();

        float time = TimeManager.Instance.time;

        PlayerPrefs.SetInt(scoreKey, ScoreManager.Instance.score);
        PlayerPrefs.SetFloat(timeKey, time);

        if (ScoreManager.Instance.score > PlayerPrefs.GetInt(scoreRecordKey))
        {
            PlayerPrefs.SetInt(scoreRecordKey, ScoreManager.Instance.score);
        }

        if (time > PlayerPrefs.GetFloat(timeRecordKey))
        {
            PlayerPrefs.SetFloat(timeRecordKey, time);
        }

        ChanceScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
