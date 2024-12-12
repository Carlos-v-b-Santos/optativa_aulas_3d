using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Image btnPause;
    [SerializeField] private Sprite btnPauseSprite;
    [SerializeField] private Sprite btnResumeSprite;
    private bool isPaused;

    private void Start()
    {
        PauseButton();
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            btnPause.sprite = btnPauseSprite;
            _pausePanel.SetActive(false);
            isPaused = false;
            GameManager.Instance.ResumeGame();
        }
        else
        {
            btnPause.sprite = btnResumeSprite;
            _pausePanel.SetActive(true);
            isPaused = true;
            GameManager.Instance.PauseGame();
        }
    }
}
