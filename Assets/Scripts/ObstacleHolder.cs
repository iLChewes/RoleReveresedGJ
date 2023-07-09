using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] public SpawnableObject spawnableObject;
    [SerializeField] public int spawnAmount;
    [SerializeField] public TMP_Text spawnAmountText;
    [SerializeField] public GameObject visual;

    private void Start()
    {
        SetNewSpawnAmountText();
        TryUpdateViusal();
    }

    public void AddSpawnAmount(int amount)
    {
        spawnAmount+= amount;
        SetNewSpawnAmountText();
        TryUpdateViusal();
    }

    public void RemoveSpawnAmount()
    {
        spawnAmount -= 1;
        SetNewSpawnAmountText();
        TryUpdateViusal();
    }

    public void SetAsNewObstacle()
    {
        BuildManager.Instance.SetObstacleHolder(this);
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
