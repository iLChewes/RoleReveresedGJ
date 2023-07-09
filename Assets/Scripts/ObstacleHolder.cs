using System;
using TMPro;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] public SpawnableObject spawnableObject;
    [SerializeField] public int initial_spawnAmount = 5;
    [HideInInspector] public int spawnAmount;

    [SerializeField] public TMP_Text spawnAmountText;
    [SerializeField] public GameObject visual;

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
    }

    public void SetAsNewObstacle()
    {
        BuildManager.Instance.SetObstacleHolder(this);
    }

    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
        TryUpdateViusal();
        SetNewSpawnAmountText();
    }

    public void TryUpdateViusal()
    {
        visual.SetActive(spawnAmount != 0);
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