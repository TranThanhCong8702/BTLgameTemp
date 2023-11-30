using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ending : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoretxt;
    [SerializeField] TextMeshProUGUI Endscoretxt;
    [SerializeField] TextMeshProUGUI Highscoretxt;
    HighSCore high;
    private void Awake()
    {
        high = FindObjectOfType<HighSCore>();
        high.ChangeHighScore(float.Parse(scoretxt.text));
    }
    void Start()
    {
        Endscoretxt.text ="Score:\n" + scoretxt.text;
        Highscoretxt.text = "HighScore\n" + PlayerPrefs.GetFloat("HighScore");
    }


    void Update()
    {
        
    }
}
