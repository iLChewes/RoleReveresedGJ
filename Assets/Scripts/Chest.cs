using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private TMP_Text coinText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.OnReachedGoal();
            StartCoroutine(nameof(SpawnCoins_Courtine));
        }
    }

    private IEnumerator SpawnCoins_Courtine()
    {
        var currentCoins = Int32.Parse(coinText.text);

        for (int i = 0; i < 100; i++)
        {
            var coin = Instantiate(coinPrefab, spawnPosition.position, Quaternion.identity);
            var coinRigi = coin.GetComponent<Rigidbody2D>();

            float speed = 600;
            coinRigi.isKinematic = false;
            Vector3 force = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), 1, 0);
            force = new Vector3(force.x, 1, force.z);
            coinRigi.AddForce(force * speed);

            currentCoins++;
            coinText.text = currentCoins.ToString();

            yield return new WaitForSeconds(0.1f);
        }
    }

}
