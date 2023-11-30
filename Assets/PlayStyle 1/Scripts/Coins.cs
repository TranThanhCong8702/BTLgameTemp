using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    bool isCollected;
    [SerializeField] AudioClip coinSound;
    [SerializeField] int addpoint = 1;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isCollected)
        {
            AudioSource.PlayClipAtPoint(coinSound, gameObject.transform.position);
            FindObjectOfType<GameSession>().AddScore(addpoint);
            isCollected = true;
            gameObject.SetActive(false);
        }
    }
}
