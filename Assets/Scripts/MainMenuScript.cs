using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject LevelSelect;
    [SerializeField] private GameObject StartScreen;

    public void OpenCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        StartScreen.SetActive(false);
        LevelSelect.SetActive(false);
    }

    public void OpenLevelSelect()
    {
        MainMenu.SetActive(false);
        StartScreen.SetActive(false);
        Credits.SetActive(false);
        LevelSelect.SetActive(true);
    }
    
    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        StartScreen.SetActive(false);
        LevelSelect.SetActive(false);
    }
    
}
