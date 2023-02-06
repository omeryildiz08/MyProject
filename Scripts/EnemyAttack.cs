using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackrange = 1f;
    public Animator anim;
    public Transform player;
    public float moveSpeed = 1.0f;
    public Rigidbody2D rb;
    private void Awake()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ApplyDamageAndAttack(collision.gameObject));
        }
    }

    private IEnumerator ApplyDamageAndAttack(GameObject player)
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f); // wait for the attack animation to finish before applying damage
        player.GetComponent<Health>().TakeDamage(attackDamage);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackrange)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }
}
