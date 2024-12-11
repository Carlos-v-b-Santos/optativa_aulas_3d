using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public float time = 0;
    public int minutes;
    public int seconds;

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um TimeManager");
            return;
        }
        Instance = this;
    }

    void Update()
    {
        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(TimeManager.Instance.time / 60);
        seconds = Mathf.FloorToInt(TimeManager.Instance.time % 60);
    }
}