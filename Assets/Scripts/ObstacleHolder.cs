using System;
using TMPro;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] public SpawnableObject spawnableObject;
    [SerializeField] public int initial_spawnAmount = 5;
    [HideInInspector] public int spawnAmount;

    [SerializeField] public TMP_Text spawnAmountText;

    private void Start()
    {
        SetSpawnAmount(initial_spawnAmount);
        if(RoundManager.Instance)
            RoundManager.Instance.OnRoundFinished += ResetAmount;
    }

    private void OnEnable()
    {
        Debug.Log("On Enable Obastacle Holder");
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
        SetSpawnAmount(spawnAmount + amount);
    }

    public void SetAsNewObstacle()
    {
        BuildManager.Instance.SetObstacleHolder(this);
    }

    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
        SetNewSpawnAmountText();
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