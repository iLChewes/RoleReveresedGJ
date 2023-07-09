using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCart : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    public float time;
    private int round;

    public void SetRoundTime(float newTime, int newRound)
    {
        this.round = newRound;
        this.time= newTime;
        textField.text = String.Format("{0}: {1:0.00}", newRound, newTime);
    }
}
