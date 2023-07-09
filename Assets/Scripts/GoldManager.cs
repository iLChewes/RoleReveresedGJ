using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private int goldAmount = 100;

    public static GoldManager Instance { get; private set; }

    public event Action OnChangeGold;

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

    public bool CanSpendGold(int spendAmount)
    {
        return goldAmount >= spendAmount;
    }

    public void RemoveGold(int goldAmount)
    {
        this.goldAmount-= goldAmount;
        OnChangeGold?.Invoke();
    }

    public void AddGold(int goldAmount)
    {
        this.goldAmount += goldAmount;
        OnChangeGold?.Invoke();
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }
}
