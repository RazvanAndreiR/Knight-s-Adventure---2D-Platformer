using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator animator;

    public FuitManager fm;



    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0) 
        {
            Die();
        }

        // inamicul pierde puncte de viata,
        // activeaza animatia lovit si, daca 
        // este cazul, activeaza algoritmul 
        // de invingere a inamicului
    }

    void Die()
    {   Player.gameObject.GetComponent<playerHealth>().health += 25;   
        // Jucatorul primeste 25 de puncte de viata la invingerea inamicului

        fm.FruitCount += 5;
        // scorul creste cu 5 puncte la invingerea inamicului

        Debug.Log("enemy died");
        // confirma invingerea inamicului in consola jocului

        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
 
        gameObject.SetActive(false);
        // activeaza animatia invingere si ascune inamicul

    }

}
