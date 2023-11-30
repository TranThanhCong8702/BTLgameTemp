using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DameDealer : MonoBehaviour
{
    [SerializeField] float dame = 10f;
    [SerializeField] bool Isbullet;
    [SerializeField] bool IsPlayerBullet;
    [SerializeField] Transform Cam;

    public float GetDmae()
    {
        return dame;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rocks")
        {
            Hit();
        }
    }
    public void Hit()
    {
        if (IsPlayerBullet)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        if (Isbullet && Vector2.Distance(transform.position, Cam.transform.position) > 8f)
        {
            if (IsPlayerBullet)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
