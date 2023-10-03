using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("New Score")]
    [SerializeField] private TMP_Text scoreText; // number 
    [SerializeField] private TMP_Text txt_scoreText; // text
    [Header("Best Score")]
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField]float animationTime;
    [SerializeField]private AnimationCurve speedCurve;
    [SerializeField]private AudioClip clickClip;
    // Start is called before the first frame update
    void Awake()
    {
        bestScoreText.text = GameManager.Instance.HighScore.ToString();
        if(!GameManager.Instance.IsInitialized)
        {
            scoreText.gameObject.SetActive(false);
            txt_scoreText.gameObject.SetActive(false);
        }else
        {
            StartCoroutine(ShowScore());
        }
    }
    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();
        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if(highScore < currentScore)
        {
            //txt_scoreText.text = "NEW BEST";
            txt_scoreText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            txt_scoreText.text = "NEW BEST";
            txt_scoreText.gameObject.SetActive(true);
            //txt_scoreText.gameObject.SetActive(false);
        }
        float speed = 1 / animationTime;
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)speedCurve.Evaluate(timeElapsed) * currentScore;
            scoreText.text = tempScore.ToString();
            yield return null;
        }
        tempScore = currentScore;
        scoreText.text = tempScore.ToString();

    }
    public void ClickedPlay()
    {
       // SoundManager.Instance.PlaySound(clickClip);
        GameManager.Instance.LoadGameplay();
    }
}
