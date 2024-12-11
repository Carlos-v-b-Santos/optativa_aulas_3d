using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool fadein = false;
    [SerializeField] private bool fadeout = false;

    [SerializeField] private float TimeToFade;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.unscaledDeltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if (fadeout == true)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.unscaledDeltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
        canvasGroup.alpha = 0;
    }

    public void FadeOut()
    {
        fadeout = true;
        canvasGroup.alpha = 1;
    }
}
