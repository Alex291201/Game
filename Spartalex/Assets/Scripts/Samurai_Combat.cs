using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Samurai_Combat : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float Check = 0f;
    public GameObject _object;
    public Score score, score2;
    AIPath aipath;


    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    nextAttackTime = Time.time + 1f / attackRate;
                    animator.SetTrigger("Attack");
                    Check = Time.time + 0.3f;

                }


            }
        }
        if (Time.time >= Check)
        {
            Attack();
            Check = Time.time + 100f;
        }
    }
    void Attack()
    {



        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Player_Damaged>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();


        }
        nextAttackTime = Time.time + 1f;
    }
    void Die()
    {
        animator.SetBool("Dead", true);
        score.SetTextValue();
        score2.SetTextValue();
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(waiter());
        this.enabled = false;
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
        _object.SetActive(false);
        yield break;

    }
}