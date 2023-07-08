using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAI : MonoBehaviour
{
    [SerializeField] private Transform goal;
    private Seeker seeker;

    public event Action OnRunStarted;
    public event Action OnRunFinished;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
    }

    public void OnStartRun()
    {
        OnRunStarted?.Invoke();
        Debug.Log("Start");
        seeker.StartPath(transform.position, goal.position);
    }

    public void OnReachedGoal()
    {
        OnRunFinished?.Invoke();
        Debug.Log("Finish");
    }
}
