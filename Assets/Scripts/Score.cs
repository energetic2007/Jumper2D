using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private int currentScore = 0;
    [SerializeField] private GameObject player;
    private int highestScore;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text highScoreText;

    private void FixedUpdate()
    {
        int currentY = Mathf.RoundToInt(player.transform.position.y);
        if (currentScore < currentY)
        {
            currentScore = currentY;
        }
        currentScoreText.text = currentScore.ToString() + " points";
        AddHighScore();
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highestScore = PlayerPrefs.GetInt("SaveScore");
            // highScoreText.text = highestScore.ToString() + " points";
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
            highScoreText.text = "Hight score: " + highestScore.ToString();
            highestScore = currentScore;
        }
    }
}
