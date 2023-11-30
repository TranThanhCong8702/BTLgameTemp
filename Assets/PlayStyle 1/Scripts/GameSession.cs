using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerlives = 3;
    [SerializeField] int playerScores = 0;
    int playerlivesendingCheck = 9;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int numOfSession = FindObjectsOfType<GameSession>().Length;
        if(numOfSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", 9);
        }
        else
        {
            playerlives = PlayerPrefs.GetInt("lives");
        }
        livesText.text = playerlives.ToString();
        scoreText.text = playerScores.ToString();
    }
    public void PlayerProcess()
    {
        if(playerlives > 1)
        {
            TakeLife();
        }
        else
        {
            //TakeLife();
            playerlives = 0;
            livesText.text = playerlives.ToString();
            ResetGameSession();
        }
    }
    public void AddScore(int addpoint)
    {
        playerScores += addpoint;
        scoreText.text = playerScores.ToString();
        FindObjectOfType<LevelExit>().display(playerScores);
    }
    private void TakeLife()
    {
        playerlives--;
        //if(playerlives <= 1)
        //{
        //    playerlives = 0;
        //}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerlives.ToString();

    }
    public string LoadExit()
    {
        return livesText.text.ToString();
    }
    private void ResetGameSession()
    {
        SceneManager.LoadScene(6);
        FindObjectOfType<ScenePersist>().ResetscenePersist();
    }
    public void DestroyGameSession()
    {
        Destroy(gameObject);
    }
}
