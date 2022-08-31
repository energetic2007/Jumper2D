using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore = 0;
    [SerializeField] private GameObject player;
    private int highestScore;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text highScoreText;

    private void FixedUpdate()
    {
        Debug.Log(player.transform.position.y);
        currentScore = (Mathf.RoundToInt(player.transform.position.y));
        currentScoreText.text = currentScore.ToString() + " points";
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highestScore = PlayerPrefs.GetInt("SaveScore");
            highScoreText.text = highestScore.ToString() + " points";
        }
    }
    /**
    Надо прочитать про подписывание на события и возможно подписать этот метод
    на Player.Die()
    */
    public void AddHighScore()
    {
        if (currentScore > highestScore)
        {
            PlayerPrefs.SetInt("SaveScore", highestScore);
            highScoreText.text = highestScore.ToString() + " points";
            highestScore = currentScore;
        }
    }
}
