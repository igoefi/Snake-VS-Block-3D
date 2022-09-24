using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager Manager;

    [SerializeField] GameObject BG;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject LoseMenu;

    [SerializeField] TMP_Text LevelText;

    private GameObject _openMenu;

    private void Start()
    {
        if(LevelText != null)
            LevelText.text = "Level: " + PlayerPrefs.GetInt("Level", 1);
    }

    public void OpenCloseMenu()
    {
        BG.SetActive(!BG.activeSelf);

        if( _openMenu != null)
        {
            _openMenu.SetActive(false);
            _openMenu = null;
            return;
        }

        GameManager.GameStates state = GameManager.GameState;
        if (state == GameManager.GameStates.Win)
            _openMenu = WinMenu;
        else if (state == GameManager.GameStates.Lose)
            _openMenu = LoseMenu;

        _openMenu.SetActive(true);  
    }

    public void Restart()
    {
        Manager.Restart();
    }

    public void GoToNextLevel()
    {
        Manager.GoToNextLevel();
    }

    public void ResetLevels()
    {
        Manager.ResetLevels();
    }
}
