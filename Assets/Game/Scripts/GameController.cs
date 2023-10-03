using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int score;
    public TMPro.TMP_Text scoreText;
    public float speedupScore;
    private float counterSpeedupScore;
    public bool isGameEnd;
    void Awake()
    {
        GameManager.Instance.IsInitialized = true;
    }
    void Update()
    {
        if(isGameEnd)
            return;
        counterSpeedupScore -= Time.deltaTime;
        if(counterSpeedupScore <= 0)
        {
            counterSpeedupScore = speedupScore;
            Scoreup();
        }
    }
    public void Scoreup()
    {
        score ++;
        scoreText.text = score.ToString();
    }
    public void GameEnd()
    {
        isGameEnd = true;
        GameManager.Instance.CurrentScore = score;
        StartCoroutine(GameOver());
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(GameManager.Instance.timeGameOver);
        GameManager.Instance.LoadMainMenu();
    }

}
