using System;
using TMPro;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] public SpawnableObject spawnableObject;
    [SerializeField] public int initial_spawnAmount = 5;
    [HideInInspector] public int spawnAmount;

    [SerializeField] public TMP_Text spawnAmountText;
    [SerializeField] public GameObject activeVisual;
    [SerializeField] public GameObject passiveVisual;

    public bool isActive;

    private void Start()
    {
        SetSpawnAmount(initial_spawnAmount);
        if(RoundManager.Instance)
            RoundManager.Instance.OnRoundFinished += ResetAmount;
    }

    private void OnEnable()
    {
        if(RoundManager.Instance)
            RoundManager.Instance.OnRoundFinished += ResetAmount;
    }

    private void OnDisable()
    {
        RoundManager.Instance.OnRoundFinished -= ResetAmount;
    }

    private void ResetAmount()
    {
        SetSpawnAmount(initial_spawnAmount);
    }

    public void AddSpawnAmount(int amount)
    {
        SetSpawnAmount( spawnAmount + amount);
    }

    public void RemoveSpawnAmount()
    {
        SetSpawnAmount(spawnAmount - 1);
        if (!CanSpawn())
        {
            isActive = false;
        }
        TryUpdateViusal();
    }

    public void SetAsNewObstacle()
    {
        BuildManager.Instance.SetObstacleHolder(this);
        isActive = true;
        TryUpdateViusal();
    }

    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
        TryUpdateViusal();
        SetNewSpawnAmountText();
    }

    public void TryUpdateViusal()
    {
        if (isActive)
        {
            activeVisual.SetActive(spawnAmount != 0);
            passiveVisual.SetActive(false);
        }
        else
        {
            passiveVisual.SetActive(spawnAmount != 0);
            activeVisual.SetActive(false);
        }    
    }

    public void SetNewSpawnAmountText()
    {
        spawnAmountText.text = spawnAmount.ToString();
    }

    public bool CanSpawn()
    {
        return spawnAmount > 0;
    }
}