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
    private int number;
    [SerializeField] private LayerMask ground;

    [Header("for running")]
    private bool isFacingRight = true;
    [SerializeField] private float moveSpeed = 4f;

    [Header("for jump")]
    private bool isGround;
    private int jumpCount;
    private int wallJumpCount;
    [SerializeField] private float jumpStrength = 10f;
    [SerializeField] private Transform pointGround;

    [Header("for sliding wall")]
    private bool canSlideWall;
    private bool isWall;
    private bool isSlidingWall;
    [SerializeField] private Transform checkWall;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGround = Physics2D.OverlapBox(pointGround.position, new Vector2(0.4f, 0.2f), 0, ground);
        isWall = Physics2D.OverlapBox(checkWall.position, new Vector2(0.15f, 0.5f), 0, ground);
        
        horizontal = Input.GetAxisRaw("Horizontal");

        runing();

        jump();

        wallJump();

        falling();

        slidingWall();
    }

    private void runing()
    {
        if (horizontal < 0f && isFacingRight || horizontal > 0f && !isFacingRight)
        {
            flip();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (isGround)
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
            if (!isGround)
            {
                jumpCount = 1;
            }
            if (jumpCount == 2 && isGround)
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

        if (isGround && rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isDoubleJumping", false);
            if (jumpCount == 1)
            {
                jumpCount = 2;
            }
            if (jumpCount == 0)
            {
                jumpCount = 2;
            }
        }
    }
    private void wallJump()
    {
        if (isSlidingWall)
        {
            jumpCount = 0;
            wallJumpCount = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && wallJumpCount != 0 || Input.GetKeyDown(KeyCode.UpArrow) && wallJumpCount != 0)
        {
            if (isWall)
            {
                flip();
                isWall = false;
            }
            
            if (wallJumpCount == 2)
            {
                anim.SetBool("isJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
            if (wallJumpCount == 1)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDoubleJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
            wallJumpCount--;
        }
    }

    private void falling()
    {
        if (!isGround && rb.velocity.y < 0 && !isSlidingWall)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
    }
    private void slidingWall()
    {
        if (!isGround && !isWall)
        {
            canSlideWall = true;
        }else
        {
            canSlideWall = false;
        }
        
        if (!isGround && isWall)
        {
            if (canSlideWall)
            {
                flip();
                checkWall.localPosition = new Vector3(-checkWall.localPosition.x, checkWall.localPosition.y, 0);
            }
            rb.velocity = new Vector2(rb.velocity.x, 0.2f);
            anim.SetBool("isSlidingWall", true);
            isSlidingWall = true;
        }
        if (!isWall || isGround && isSlidingWall)
        {
            checkWall.localPosition = new Vector3(Mathf.Abs(checkWall.localPosition.x), checkWall.localPosition.y, 0);
            anim.SetBool("isSlidingWall", false);
            isSlidingWall = false;
        }
    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 0);
        isFacingRight = !isFacingRight;
    }
}
