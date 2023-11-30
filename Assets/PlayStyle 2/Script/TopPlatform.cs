using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlatform : MonoBehaviour
{
    GameControlType2 gameControlType;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameControlType.PlayerProcess();
        }
    }
    void Start()
    {
        gameControlType = FindObjectOfType<GameControlType2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
