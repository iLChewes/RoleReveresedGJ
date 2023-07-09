using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{

    [SerializeField] private TMP_Text timeNeedText;

    [SerializeField] private AudioSource spinWheel;

    private float sumTime;

    private void OnEnable()
    {
        Debug.Log("Start Result Screen");

        var timeCarts = TimeTable.Instance.timeCartList;

        sumTime = timeCarts.Sum(x => x.time);

        StartCoroutine(nameof(SumUpTime));
    }

    private IEnumerator SumUpTime()
    {
        spinWheel.Play();
        float currentTime = 0f;
        while(currentTime < sumTime)
        {
            currentTime += 0.02f;
            if (currentTime >= sumTime)
            {
                currentTime = sumTime;
            }

            UpdateTimeText(currentTime);
            yield return null;
        }

        spinWheel.Stop();
    }

    private void UpdateTimeText(float time)
    {
        timeNeedText.text = string.Format("{0:0.00} s", time);
    }
}
