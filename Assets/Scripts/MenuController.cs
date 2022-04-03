using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
  InGame,
  Pause,
  TryAgain,
  MainMenu
}

public class MenuController : MonoBehaviour
{
  [SerializeField] GameObject PauseWindow;
  [SerializeField] GameObject MenuWindow;
  [SerializeField] GameObject DeathWindow;
  [SerializeField] GameObject GameWindow;
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
    UpdateGameState(GameState.MainMenu);
    _instance = this;
  }
  public void OpenMenu() { UpdateGameState(GameState.MainMenu); }
  public void StartGame()
  {
    UpdateGameState(GameState.InGame);
  }
  public void Pause() { UpdateGameState(GameState.Pause); }
  public void OpenTryAgain() { UpdateGameState(GameState.TryAgain); }

  public void UpdateGameState(GameState nextState)
  {
    MenuWindow.SetActive(nextState == GameState.MainMenu);
    DeathWindow.SetActive(nextState == GameState.TryAgain);
    PauseWindow.SetActive(nextState == GameState.Pause);
    GameWindow.SetActive(nextState == GameState.InGame);
    Time.timeScale = nextState == GameState.InGame ? 1 : 0;
  }
}
