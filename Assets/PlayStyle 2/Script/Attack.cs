using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //[SerializeField] Transform startPos;
    [SerializeField] float flySpeed = 1f;
    [SerializeField] List<Vector3> spawnPos = new List<Vector3>();
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
        i = Random.Range(0, spawnPos.Count);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision == capsuleCollider)
        {
            coll.enabled = false;
            transform.GetComponent<Animator>().SetBool("explode", true);
            game.PlayerProcess();
            Invoke("Des", 1f);
        }
    }
    public void Fire()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(flySpeed, 0);
    }
    // Update is called once per frame
    void Update()
    {
        Destroy();
    }
    private void Destroy()
    {
        if (Vector2.Distance(transform.position, spawnPos[i]) >= 18f)
        {
            Des();
        }
    }

    private void Des()
    {
        gameObject.SetActive(false);
        coll.enabled = true;
        transform.position = /*new Vector3(8.45f, -2.18f, 0)*/ spawnPos[i];
    }
}
