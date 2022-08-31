using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Select(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}