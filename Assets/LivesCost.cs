using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesCost : MonoBehaviour
{
    [SerializeField] float cost = 100f;
    [SerializeField] TextMeshProUGUI cost1;
    void Start()
    {
        cost1.text = cost.ToString();
    }
    public void MoreLives()
    {
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", 9);
        }
        else
        {
            int t = PlayerPrefs.GetInt("lives");
            PlayerPrefs.SetInt("lives", t+1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
