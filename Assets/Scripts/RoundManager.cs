using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int currentRound;
    [SerializeField] private int maxRound;

    [SerializeField] private TMP_Text roundText;


    public static RoundManager Instance { get; private set; }
    
    public event Action OnRoundFinished;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetRoundText();
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }

    public bool IsLastRound()
    {
        return currentRound == maxRound;
    }

    public void NextRound()
    {
        Debug.Log("NextRound called");
        currentRound++;
        OnRoundFinished?.Invoke();
        if(currentRound > maxRound) { currentRound = maxRound; }

        SetRoundText();
    }

    public void SetRoundText()
    {
        roundText.text = currentRound  + " / " + maxRound;
    }
}
