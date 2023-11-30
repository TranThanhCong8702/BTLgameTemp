using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsType2 : MonoBehaviour
{
    PlayerMovementType2 playerMovement;
    CapsuleCollider2D capsuleCollider;
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovementType2>();
        capsuleCollider = playerMovement.GetCapsuleCollider();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!playerMovement.GetPlayerStatus()) return;
        if (collision.transform.tag == "Player" && collision == capsuleCollider)
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            FindObjectOfType<GameControlType2>().PlayerPoints();
            transform.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
