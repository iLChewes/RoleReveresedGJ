using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject coinIcon;
    [SerializeField] private Transform thiefStartPosition;
    [SerializeField] private ToggleStartButton toggleButton;
    [SerializeField] private TimeTable timeTable;
    [SerializeField] private GameObject lastRoundText;
    [SerializeField] private GameObject resultScreen;
    [SerializeField] private float CoinSpawnDelay = 0.05f;

    private ThiefAI thiefAI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            this.thiefAI = thiefAi;
            thiefAi.OnReachedGoal();
            StartCoroutine(nameof(SpawnCoins_Courtine));
        }
    }

    private IEnumerator SpawnCoins_Courtine()
    {
        var currentCoins = Int32.Parse(coinText.text);

        for (int i = 0; i < 10; i++)
        {
            var coin = Instantiate(coinPrefab, spawnPosition.position, Quaternion.identity);
            var coinRigi = coin.GetComponent<Rigidbody2D>();

            float speed = 450;
            coinRigi.isKinematic = false;
            Vector3 force = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), 1, 0);
            force = new Vector3(force.x, 1, force.z);
            coinRigi.AddForce(force * speed);

            currentCoins--;
            coinText.text = currentCoins.ToString();

            yield return new WaitForSeconds(CoinSpawnDelay);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(nameof(SpawnCoinsToUI_Courtine));
    }

    private IEnumerator SpawnCoinsToUI_Courtine()
    {
        var currentCoins = Int32.Parse(coinText.text);
        for (int i = currentCoins; i > 0; i--)
        {
            var coin = Instantiate(coinPrefab, spawnPosition.position, Quaternion.identity);
            var flyTo = coin.GetComponent<FlyToUI>();
            
            flyTo.SetFlyTo(coinIcon);
            flyTo.StartFlying();

            currentCoins--;
            coinText.text = currentCoins.ToString();

            yield return new WaitForSeconds(CoinSpawnDelay);
        }
        yield return new WaitForSeconds(0.75f);


        if (!RoundManager.Instance.IsLastRound())
        {
            StartCoroutine(nameof(MoveThiefToStartPosition_Courtine));
        }
        else
        {
            timeTable.CreateTimeCart(RoundManager.Instance.GetCurrentRound(), RunTimer.Instance.GetCurrentTime());
            var timeCarts = TimeTable.Instance.timeCartList;

            var sumTime = timeCarts.Sum(x => x.time);

            var currentHighScore = HighScoreTracker.Instance.GetHighScoreOfLevel(LevelManager.Instance.currentLevel);

            if(sumTime > currentHighScore)
            {
                HighScoreTracker.Instance.SetHighScoreLevel(LevelManager.Instance.currentLevel, sumTime);
            }

            ActivateResultScreen();
        }
    }

    private IEnumerator MoveThiefToStartPosition_Courtine()
    {
        thiefAI.enabled = false;
        var thiefGO = thiefAI.gameObject;
        var thiefCollider = thiefGO.GetComponent<CircleCollider2D>();
        thiefCollider.enabled = false;

        var worldPosition = thiefStartPosition.position;

        while (Vector3.Distance(thiefGO.transform.position, worldPosition) > 0.001f)
        {
            var step = 10 * Time.deltaTime;
            thiefGO.transform.position = Vector3.MoveTowards(thiefGO.transform.position, worldPosition, step);
            yield return null;
        }

        thiefAI.enabled = true;
        thiefCollider.enabled = true ;

        ResetGold();
        toggleButton.ActivateButton();
        timeTable.CreateTimeCart(RoundManager.Instance.GetCurrentRound(), RunTimer.Instance.GetCurrentTime());
        RoundManager.Instance.NextRound();

        if (RoundManager.Instance.IsLastRound())
        {
            lastRoundText.SetActive(true);
            Invoke(nameof(DeActivateLastRoundText), 3f);
        }

    }

    public void ActivateResultScreen()
    {
        resultScreen.SetActive(true);
    }

    public void DeActivateLastRoundText()
    {
        lastRoundText.SetActive(false);
    }

    private void ResetGold()
    {
        coinText.text = "40";
    }

}
