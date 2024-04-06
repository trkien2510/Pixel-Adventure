using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float moveSpeed = 3f;
    float moveRange;
    float currentPosition;
    int horizontal;
    bool isFacingRight = true;
    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        currentPosition = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(RandomMove());
    }
    void Update()
    {
        if (rb != null)
        {
            rb.gravityScale = 1.5f;
        }

        ChangeMove();

        moveRange = GetComponent<BoxCollider2D>().enabled ? 2f : 100f;
    }
    private void Run()
    {
        if (horizontal < 0f && isFacingRight || horizontal > 0f && !isFacingRight)
        {
            Flip();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    private void ChangeMove()
    {
        if (currentPosition - moveRange >= transform.position.x && !isFacingRight || currentPosition + moveRange <= transform.position.x && isFacingRight)
        {
            Flip();
            horizontal = -horizontal;
            Run();
        }
    }
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 0);
        isFacingRight = !isFacingRight;
    }
    IEnumerator RandomMove()
    {
        horizontal = Random.Range(-1, 2);
        Run();
        yield return new WaitForSeconds(2);
        StartCoroutine(RandomMove());
    }
}
