using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] Sprite img;
    Rigidbody2D rb;
    Animator Anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetBool("isDead", true);
            StartCoroutine(WaitToDead());
        }
    }
    IEnumerator WaitToDead()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        rb.velocity = new Vector2 (0, 6f);
        yield return new WaitForSeconds(0.1f);
        Anim.SetBool("isDead", false);
        GetComponent<SpriteRenderer>().sprite = img;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
