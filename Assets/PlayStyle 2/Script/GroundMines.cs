using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMines : MonoBehaviour
{
    [SerializeField] float flySpeed = 1f;
    [SerializeField] float waitTime = 1f;
    [SerializeField] float AirAmount = 1f;
    [SerializeField] Transform Player;
    int i = 0;

    Rigidbody2D rb;
    GameControlType2 game;
    PlayerMovementType2 playerMovement;
    CapsuleCollider2D capsuleCollider;
    [SerializeField] BoxCollider2D coll;
    private void Awake()
    {
        game = FindObjectOfType<GameControlType2>();
        playerMovement = FindObjectOfType<PlayerMovementType2>();
        capsuleCollider = playerMovement.GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        transform.position = new Vector3(Player.position.x, -3.61f ,0) /*+ new Vector3 (0, 1f, 0)*/;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision == capsuleCollider)
        {
            game.PlayerProcess();
            game.PlayerProcess();
            coll.enabled = false;
            Player.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, AirAmount);
        }
    }
    void KaBoom()
    {
        coll.enabled = true;
        transform.position += new Vector3(0,2f,0);
        transform.GetComponent<Animator>().SetBool("f2explode", true);
        Invoke("Des", 1f);
    }
    public void Fire()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(flySpeed, 0);
        Invoke("KaBoom", waitTime);
    }
    // Update is called once per frame
    void Update()
    {
        //Destroy();
    }
    private void Destroy()
    {
        //if (Vector2.Distance(transform.position, spawnPos[i]) >= 18f)
        //{
            Des();
        //}
    }

    private void Des()
    {
        gameObject.SetActive(false);
        coll.enabled = false;
        transform.position = /*new Vector3(8.45f, -2.18f, 0)*/ new Vector3(Player.position.x, -3.61f, 0);
    }
}
