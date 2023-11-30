using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float WaitTime = 1f;
    [SerializeField] int scoreToPass = 3;
    [SerializeField] SpriteRenderer exit;
    [SerializeField] float x = 1f;
    [SerializeField] float y = 1f;
    [SerializeField] float z = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }

    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(WaitTime);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetscenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
    private void Start()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    gameObject.SetActive(true);
        //}
        //int currscore = FindObjectOfType<GameSession>().LoadExit(); -2.037202 -4.070117 
        //Debug.Log(currscore);
        //Debug.Log(scoreToPass);/*-2.037202f, - 4.070117f,0f*/
    }
    public void display(int currscore)
    {
        //int currscore = FindObjectOfType<GameSession>().LoadExit();
        if (currscore >= scoreToPass /*&& SceneManager.GetActiveScene().buildIndex == 5*/)
        {
            exit./*transform.position = new Vector3(x,y,z)*/enabled = true;
        }
        //else if (SceneManager.GetActiveScene().buildIndex == 6)
        //{
        //    gameObject.transform.position = new Vector3(x, y, z);
        //}
    }
}
