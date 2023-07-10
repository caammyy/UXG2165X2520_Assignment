using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    public Animator anim;

    public int slimeHealth = 10;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = slimeHealth;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt anim
        anim.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log(currentHealth);
        //anim
        anim.SetBool("dead", true);
        //disable
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
