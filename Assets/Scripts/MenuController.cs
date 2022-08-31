using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    InGame,
    Pause,
    TryAgain
}

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject PauseWindow;
    [SerializeField] GameObject DeathWindow;
    [SerializeField] GameObject MainUI;
    private static MenuController _instance;
    public static MenuController Instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        UpdateGameState(GameState.InGame);
        _instance = this;
    }
    public void StartGame()
    {
        UpdateGameState(GameState.InGame);
    }
    public void Pause() { UpdateGameState(GameState.Pause); }
    public void OpenTryAgain() { UpdateGameState(GameState.TryAgain); }

    public void UpdateGameState(GameState nextState)
    {
        DeathWindow.SetActive(nextState == GameState.TryAgain);
        PauseWindow.SetActive(nextState == GameState.Pause);
        MainUI.SetActive(nextState == GameState.InGame);
        Time.timeScale = nextState == GameState.InGame ? 1 : 0;
    }
}
