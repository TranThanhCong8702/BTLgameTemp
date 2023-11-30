using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 MoveInput;
    Rigidbody2D MyRigidbody;
    Animator animator;
    CapsuleCollider2D Mycap;
    BoxCollider2D Mybox;

    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 12f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float NormalLaddGra = 8;
    [SerializeField] float OnLaddGra = 0;
    [SerializeField] bool isAlive = true;
    [SerializeField] Vector2 dieStyle = new Vector2(20f, 20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] ParticleSystem Blodd;
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Mycap= GetComponent<CapsuleCollider2D>();
        Mybox = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        SetAlive();
    }
    private void ClimbLadder()
    {
        if (!Mycap.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        {
            animator.SetBool("IsClimbing", false);
            MyRigidbody.gravityScale = NormalLaddGra;
            return; 
        }
        Vector2 move = new Vector2(MyRigidbody.velocity.x, MoveInput.y * climbSpeed);
        MyRigidbody.velocity = move;
        MyRigidbody.gravityScale = OnLaddGra;
        bool isRunning = Mathf.Abs(MyRigidbody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimbing", isRunning);
    }

    private void FlipSprite()
    {
        bool hasRunningSpeed = Mathf.Abs(MyRigidbody.velocity.x) > 0 /*Mathf.Epsilon*/;

        if (hasRunningSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(MyRigidbody.velocity.x), 1f);
        }
    }
    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!Mybox.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if (value.isPressed)
        {
            MyRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
     void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        if (value.isPressed)
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }
    private void Run()
    {
        Vector2 move = new Vector2(MoveInput.x * runSpeed, MyRigidbody.velocity.y);
        MyRigidbody.velocity = move;

        bool isRunning = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", isRunning);
    }
    void OnMove(InputValue inputValue)
    {
        if (!isAlive) { return; }
        MoveInput = inputValue.Get<Vector2>();
        Debug.Log(MoveInput);
    }
    void SetAlive()
    {
        if (MyRigidbody.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            Blodd.Play();
            animator.SetTrigger("isDie");
            MyRigidbody.velocity = dieStyle;
            Invoke("Alive", 1f);
            //FindObjectOfType<GameSession>().PlayerProcess();
        }
    }
    void Alive()
    {

        FindObjectOfType<GameSession>().PlayerProcess();
    }
}
