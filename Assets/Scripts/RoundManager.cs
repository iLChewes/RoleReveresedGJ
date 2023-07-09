using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int currentRound;
    [SerializeField] private int maxRound;

    [SerializeField] private TMP_Text roundText;

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
        currentRound++;
        if(currentRound > maxRound) { currentRound = maxRound; }

        SetRoundText();
    }

    public void SetRoundText()
    {
        roundText.text = currentRound  + " / " + maxRound;
    }
}