using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Damaged : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HealthBar healthbar;
    public GameObject DeadMenuUI;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);

    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
      
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        healthbar.SetHealth(currentHealth);
    }
    void Die()
    {
        
        animator.SetBool("Dead", true);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = true;
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        StartCoroutine(waiter());
        
        this.enabled = false;
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        DeadMenuUI.SetActive(true);
        yield break;

    }
}
