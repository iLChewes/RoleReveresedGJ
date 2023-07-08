using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class LevelSelectPanelScript : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private string levelName;
    [SerializeField] private SceneReference levelToLoad;

    [Header("Setup")]    
    [SerializeField] private TextMeshProUGUI levelNameText;

    private void Update()
    {
        if(!levelNameText)
            return;
        
        levelNameText.SetText(levelName);
    }

    public void LoadLevel()
    {
        if(levelToLoad != null)
        {
            SceneManager.LoadScene(levelToLoad.ScenePath);
        }
    }
}
