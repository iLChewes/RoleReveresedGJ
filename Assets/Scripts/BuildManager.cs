using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private ObstacleHolder currentObstacleHolder;

    public static BuildManager Instance { get; private set; }

    public event Action<ObstacleHolder> OnObstacleChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public ObstacleHolder GetObstacleHolder()
    {
        return currentObstacleHolder;
    }
    public void SetObstacleHolder(ObstacleHolder newObstacle)
    {
        this.currentObstacleHolder = newObstacle;
        OnObstacleChanged?.Invoke(currentObstacleHolder);
    }
}
