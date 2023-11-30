using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlType2 : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livestxt;
    [SerializeField] TextMeshProUGUI scoretxt;
    PlayerMovementType2 playerMovement;
    SceneController sceneController;
    ParticleSystemOlay particle;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovementType2>();
        sceneController = FindObjectOfType<SceneController>();
        particle = FindObjectOfType<ParticleSystemOlay>();
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", 9);
        }
        else
        {
            lives = PlayerPrefs.GetInt("lives");
        }
        livestxt.text = lives.ToString();
        scoretxt.text = score.ToString();
    }
    public void PlayerProcess()
    {
        if (!playerMovement.GetPlayerStatus()) return;
        if (lives > 1)
        {
            particle.ParticlePlay();
            TakeLife();
        }
        else
        {
            particle.ParticlePlay();
            lives = 0;
            livestxt.text = lives.ToString();
            playerMovement.Die();
            sceneController.StopST();
        }
    }
    public void PlayerPoints()
    {
        score++;
        scoretxt.text = score.ToString();
    }
    private void Reset()
    {
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        lives--;
        livestxt.text = lives.ToString();
    }
    public void InstantDeath()
    {
        lives = 0;
    }
}
