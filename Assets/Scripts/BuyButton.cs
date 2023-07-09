using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private ObstacleHolder obstacleHolder;
    [SerializeField] private int goldCost;
    [SerializeField] private TMP_Text costText;

    private AudioSource audioSource;

    private void Start()
    {
        costText.text = goldCost.ToString();
        audioSource = GetComponent<AudioSource>();
    }


    public void TryBuyObstacle()
    {
        if (GoldManager.Instance.CanSpendGold(goldCost))
        {
            obstacleHolder.AddSpawnAmount(1);
            GoldManager.Instance.RemoveGold(goldCost);
            audioSource.Play();
        }
    }
}
