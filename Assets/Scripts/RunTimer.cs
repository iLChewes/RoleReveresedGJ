using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RunTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private ThiefAI thiefAi;

    private float currentTime;

    private void OnEnable()
    {
        thiefAi.OnRunStarted += StartTimer;
        thiefAi.OnRunFinished += EndTimer;
    }

    private void OnDisable()
    {
        thiefAi.OnRunStarted -= StartTimer;
        thiefAi.OnRunFinished -= EndTimer;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    private void StartTimer()
    {
        AstarPath.active.Scan();
        currentTime = 0;
        Debug.Log("Timer S");
        StartCoroutine(nameof(Timer_Courtine));
    }

    private void EndTimer()
    {
        StopCoroutine(nameof(Timer_Courtine));
        SetTimeField();
    }

    private IEnumerator Timer_Courtine()
    {
        while (true)
        {
            currentTime += Time.deltaTime;
            SetTimeField();
            yield return null;
        }
    }

    private void SetTimeField()
    {
        timeText.text = String.Format("{0:0.00}", currentTime);
    }
}
