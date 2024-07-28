using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTimeInSeconds = 120f;
    [SerializeField] private TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool timeout;

    void Start()
    {
        timeRemaining = totalTimeInSeconds;
        UpdateTimerText();
    }

    void Update()
    {
        if (timeRemaining > 0 && !timeout)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                ObjectiveManager.instance.TimeOut();
                timeout = true;
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
