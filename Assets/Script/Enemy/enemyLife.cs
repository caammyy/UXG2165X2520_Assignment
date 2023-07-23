using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    public Animator anim;

    public int iniHealth;
    int currentHealth;

    public int enemyXP;

    public bool death;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = iniHealth;
        death = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt anim
        anim.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            death = true;
            Die();
        }
    }
    void Die()
    {
        //anim
        anim.SetBool("move", false);
        anim.SetBool("dead", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        //player xp
        GameObject p = GameObject.Find("/PlayerController/Player(Clone)");
        p.GetComponent<playerLife>().playerXP += enemyXP;

        //disable
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Destroy(this);
    }
}
