using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    public Animator anim;
    public GameObject enemy;
    private score scoreManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = MaxHealth;
        scoreManager = FindObjectOfType<score>();
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

      
            if (currentHealth <= 0)
            {
                Die();
               

            }
        
      
    }

    void Die()
    {

        
        anim.SetTrigger("die");

        StartCoroutine(DeathRoutine());
      
        
        //Disable the enemy
    }

    private IEnumerator DeathRoutine()
    {
        // Wait for 1-2 seconds
        yield return new WaitForSeconds(0.5f);
        // Destroy the object
        Destroy(enemy);
        scoreManager.increaseScore += 1; 
    }
}
