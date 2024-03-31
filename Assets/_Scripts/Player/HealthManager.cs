using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    int currentHealth;
    int maxHealth = 3;
    bool canTakeDamage = true;
    Rigidbody2D rb;
    Animator anim;
    Renderer Renderer;
    GameObject Heart;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Renderer = GetComponent<Renderer>();
        Heart = GameObject.FindGameObjectWithTag("Heart");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canTakeDamage)
        {
            TakeDamage();
            StartCoroutine(WaitForTakeDamage());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            Healing();
            Heart.SetActive(false);
        }
    }
    void TakeDamage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            StartCoroutine(WaitEndAnim(anim, "isDead"));
            GetComponent<PlayerMovement>().enabled = false;
            rb.velocity = new Vector2 (0, 0);
            StartCoroutine(WaitToDead());
        }
        else
        {
            StartCoroutine(WaitEndAnim(anim, "damaged"));   
        }
    }
    void Healing()
    {
        currentHealth += 1;
        if (currentHealth >= 3)
        {
            currentHealth = 3;
        }
    }
    IEnumerator WaitForTakeDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(3f);
        canTakeDamage = true;
    }
    IEnumerator WaitToDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(rb);
        Renderer.enabled = false;
    }
    IEnumerator WaitEndAnim(Animator animation, string name)
    {
        animation.SetBool(name, true);
        yield return new WaitForSeconds(0.1f);
        animation.SetBool(name, false);
    }
}
