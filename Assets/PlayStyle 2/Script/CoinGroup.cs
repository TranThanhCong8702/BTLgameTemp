using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : MonoBehaviour
{
    [SerializeField] float EnemySpeed;
    [SerializeField] float SpeedUp;
    PlayerMovementType2 playerMovement;
    [SerializeField] Transform spawnPos;
    //Rigidbody2D rigidbody2;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovementType2>();
    }
    void EnemyMoving()
    {
        transform.position += new Vector3(EnemySpeed * Time.deltaTime, 0, 0);
    }
    private void Update()
    {
        if (!playerMovement.GetPlayerStatus()) { return; }
        else
        {
            EnemyMoving();
        }
        if(Vector2.Distance(transform.position, spawnPos.position) >= 18f)
        {
            foreach(Transform t in this.transform)
            {
                if (!t.gameObject.activeInHierarchy)
                {
                    t.gameObject.SetActive(true);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
