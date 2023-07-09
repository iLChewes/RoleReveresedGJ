using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{
    private Dictionary<int, float> scores = new Dictionary<int, float>();

    public static HighScoreTracker Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            scores.Add(1, 0f);
            scores.Add(2, 0f);
            scores.Add(3, 0f);
            Instance = this;
            DontDestroyOnLoad(this);
        }   
    }

    public float GetHighScoreOfLevel(int level)
    {
        return scores[level];
    }

    public void SetHighScoreLevel(int level, float time)
    {
        scores[level] = time;
    }
}
