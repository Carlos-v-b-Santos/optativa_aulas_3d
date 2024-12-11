using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    // Update is called once per frame
    void Update()
    {
        clockText.text = string.Format("{0:00}:{1:00}", TimeManager.Instance.minutes, TimeManager.Instance.seconds);
    }
}
