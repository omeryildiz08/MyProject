using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    public SpriteRenderer sprite;
    public GameManager manager;
    public Animator anim;
    private void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

  IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(1f);
        sprite.color = Color.white;
            
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        StartCoroutine(FlashRed());

        if (currentHealth <= 0 )
        {
            //we are dead
            //play death animation
            Die();
            gameObject.SetActive(false);
            //show gameover screen
            manager.GameOver();
        }
       
        
    }

    void Die()
    {
        anim.SetBool("isDead", true);

    }


}
