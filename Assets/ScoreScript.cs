using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    private int scoreNumber;
    public GameOverScript gameOver;

    void Start()
    {
        scoreNumber = 0;
        scoreText.text = "Score : " + scoreNumber;
    }

    private void OnTriggerEnter2D(Collider2D Flag)
    {
        if(Flag.tag == "Finish")
        {
            scoreNumber += 1;
            scoreText.text = "Score : " + scoreNumber;
        }
    }

    public void GameOver()
    {
        gameOver.Setup(scoreNumber);
    }
}
