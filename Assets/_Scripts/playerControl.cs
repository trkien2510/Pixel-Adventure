using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class playerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    private bool canJump;
    private bool isFacingRight = true;
    [SerializeField] private int jumpCount = 2;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpStrength = 10f;
    [SerializeField] private Transform pointGround;
    [SerializeField] private Transform pointWallCheckFront;
    [SerializeField] private LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        canJump = Physics2D.OverlapCircle(pointGround.position, 0.08f, ground);
        
        horizontal = Input.GetAxisRaw("Horizontal");

        runing();

        jump();

        climbWall();
    }

    private void runing()
    {
        if (horizontal < 0f && isFacingRight || horizontal > 0f && !isFacingRight)
        {
            flip();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (canJump)
        {
            anim.SetFloat("isRuning", Mathf.Abs(horizontal));
        }
        else
        {
            anim.SetFloat("isRuning", 0);
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0 || Input.GetKeyDown(KeyCode.UpArrow) && jumpCount != 0)
        {
            if (jumpCount == 2)
            {
                anim.SetBool("isJumping", true);
            }
            if (jumpCount == 1)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDoubleJumping", true);
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            jumpCount--;
        }
        if (canJump && rb.velocity.y == 0)
        {
            if (jumpCount == 1)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDoubleJumping", false);
                jumpCount = 2;
            }
            if (jumpCount == 0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDoubleJumping", false);
                jumpCount = 2;
            }
        }
    }
    private void climbWall()
    {
        
    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 0);
        isFacingRight = !isFacingRight;
    }
}
