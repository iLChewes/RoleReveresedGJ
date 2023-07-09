using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] public SpawnableObject spawnableObject;
    [SerializeField] public int spawnAmount;

    [SerializeField] public TMP_Text spawnAmountText;

    private void Start()
    {
        SetNewSpawnAmountText();
    }

    public void AddSpawnAmount(int amount)
    {
        spawnAmount+= amount;
        SetNewSpawnAmountText();
    }

    public void SetAsNewObstacle()
    {
        BuildManager.Instance.SetObstacleHolder(this);
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
