using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager UI;
    public enum GameStates 
    {
        Win,
        Lose,
        Playing
    }

    static public GameStates GameState { get; private set; }
    private GameStates _lastState;

    private void Start()
    {
        GameState = GameStates.Playing;
        _lastState = GameState;
    }

    private void Update()
    {
        if (GameState == _lastState) return;

        _lastState = GameState;
        UI.OpenCloseMenu();
    }

    static public void SetGameState(GameStates state)
    {
        GameState = state;
    }

    public void Restart()
    {
        LoadScene();
    }

    public void GoToNextLevel()
    {
        int level = PlayerPrefs.GetInt("Level", 1) +1;
        PlayerPrefs.SetInt("Level", level);

        LoadScene();
    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteKey("Level");
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
