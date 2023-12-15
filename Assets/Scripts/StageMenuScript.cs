using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenuScript : MonoBehaviour
{
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;

    [SerializeField] private GameObject lockLevel2;
    [SerializeField] private GameObject lockLevel3;
    
    [SerializeField] private bool unlockAllLevels;

    private void OnEnable()
    {
        var level2 = HighScoreTracker.Instance.GetHighScoreOfLevel(1);   
        var level3 = HighScoreTracker.Instance.GetHighScoreOfLevel(2);   

        if(level2 > 0f || unlockAllLevels)
        {
            level2Button.enabled = true;
            lockLevel2.SetActive(false);
        }

        if (level3 > 0f || unlockAllLevels)
        {
            level3Button.enabled = true;
            lockLevel3.SetActive(false);
        }
    }
}
