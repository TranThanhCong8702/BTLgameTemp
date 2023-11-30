using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighSCore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretxt;
    float highScore = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            Save();
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeHighScore(float temp)
    {
        if(highScore < temp)
        {
            highScore = temp;
            Save();
            Load();
        }
    }
    private void Load()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");
        scoretxt.text = "HighScore\n" + highScore.ToString();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
    }

    void Update()
    {
        Save();
    }
}
