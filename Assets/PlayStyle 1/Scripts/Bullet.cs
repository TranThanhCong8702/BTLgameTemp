using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D BulletRb;
    [SerializeField] float bulletSpeed = 25f;
    PlayerMovement player;
    float newX;
    void Start()
    {
        BulletRb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
        newX = player.transform.localScale.x;
    }

    void Update()
    {
        BulletRb.velocity = new Vector2(bulletSpeed * newX, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
