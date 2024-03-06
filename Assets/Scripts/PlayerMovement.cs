using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5;
    private float jumpStrength = 7;
    private bool isFaceingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0 && !isFaceingRight)
        {
            transform.localScale = new Vector3(- transform.localScale.x, 1, 0);
            isFaceingRight = !isFaceingRight;
        }
        if (horizontal > 0 && isFaceingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 0);
            isFaceingRight = !isFaceingRight;
        }
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpStrength);
        }
    }
}
