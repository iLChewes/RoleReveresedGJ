using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreLevel1;
    [SerializeField] private TMP_Text highScoreLevel2;
    [SerializeField] private TMP_Text highScoreLevel3;

    private void OnEnable()
    {
        highScoreLevel1.text = String.Format("{0:0.00} s",HighScoreTracker.Instance.GetHighScoreOfLevel(1));
        highScoreLevel2.text = String.Format("{0:0.00} s",HighScoreTracker.Instance.GetHighScoreOfLevel(2));
        highScoreLevel3.text = String.Format("{0:0.00} s",HighScoreTracker.Instance.GetHighScoreOfLevel(3));
    }
}
