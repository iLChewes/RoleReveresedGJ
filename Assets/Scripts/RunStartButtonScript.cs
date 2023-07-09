using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunStartButtonScript : MonoBehaviour
{
    [SerializeField] private AudioHandler audioHandler;
    [SerializeField] private ToggleStartButton toggleStartButton;
    [SerializeField] private ThiefAI thiefAI;
    [SerializeField] private GameObject errorMessage;

   private List<ObstacleHolder> obstacles;

    private void Start()
    {
        obstacles = FindObjectsByType<ObstacleHolder>(FindObjectsSortMode.None).ToList();
    }

    public void TryStarRun()
    {
        foreach (var obstacle in obstacles)
        {
            if(obstacle.spawnAmount != 0)
            {
                // Todo spawn music error
                if (!errorMessage.active)
                {
                    errorMessage.SetActive(true);
                    Invoke(nameof(SetErrorMessageNotActive), 2f);
                }              

                return;
            }
        }

        audioHandler.OnPlayButtonAction();
        toggleStartButton.DisableButton();
        thiefAI.OnStartRun();
    }

    private void SetErrorMessageNotActive()
    {
        errorMessage.SetActive(false);
    }
}
