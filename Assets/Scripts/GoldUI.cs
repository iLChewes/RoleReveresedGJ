using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
        UpdateGoldText();
        GoldManager.Instance.OnChangeGold += UpdateGoldText;
    }
    private void UpdateGoldText()
    {
        goldText.text = GoldManager.Instance.GetGoldAmount().ToString();
    }
}
