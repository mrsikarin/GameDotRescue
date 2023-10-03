using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeGameOver = 2f;
    private string highScoreKey = "HighScore";
    public int HighScore
    {
        get { return PlayerPrefs.GetInt(highScoreKey, 0); }
        set { PlayerPrefs.SetInt(highScoreKey, value); }
    }
    private int currentScore = 0;
    public int CurrentScore
    {
        get;
        set;
    }
    public bool IsInitialized = false;
    private const string MainMenu = "MainMenu";
    private const string Gameplay = "Level";
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
            return;
        }
    }

    public void Init()
    {
        CurrentScore = 0;
        IsInitialized = false;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene(Gameplay);
    }
}
