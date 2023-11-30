using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    Rigidbody2D eneRb;
    void Start()
    {
        eneRb = GetComponent<Rigidbody2D>();
    }
    void EMoving()
    {
        eneRb.velocity = new Vector2(EnemySpeed, 0);
    }
    void Update()
    {
        EMoving();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemySpeed = -EnemySpeed;
        FlipEnemy();
    }

    private void FlipEnemy()
    {
        transform.localScale = new Vector2(-Mathf.Sign(eneRb.velocity.x), 1f);
    }
}
