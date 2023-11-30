using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hp : MonoBehaviour
{
    [SerializeField] float Health = 10f;
    [SerializeField] bool isBoss;
    [SerializeField] GameObject MetgameObject;
    float MaxHp;
    public float GetHp()
    {
        return Health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameDealer dameDealer = collision.GetComponent<DameDealer>();
        if (dameDealer != null)
        {
            TakeDame(dameDealer.GetDmae());
            dameDealer.Hit();
        }
    }
    void TakeDame(float dame)
    {
        Health -= dame;
        if (Health <= 0)
        {
            //if (!IsPlayer && score != null)
            //{
            //    score.AddScore(Points);
            //}
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        MaxHp = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoss && Health == MaxHp / 2)
        {
            if(MetgameObject.activeInHierarchy == false)
            {
                MetgameObject.SetActive(true);
            }

        }
        else if(isBoss && Health <= MaxHp / 4)
        {
            if (MetgameObject.activeInHierarchy == false)
            {
                MetgameObject.SetActive(true);
            }
        }
    }
}
