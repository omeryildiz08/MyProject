using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    [SerializeField] public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 100;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //attack animasyonunu oynat
        anim.SetTrigger("Attack");
        //alandaki düşmanı detect et
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //hasar
        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<EnemyHP>().TakeDamage(attackDamage);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
