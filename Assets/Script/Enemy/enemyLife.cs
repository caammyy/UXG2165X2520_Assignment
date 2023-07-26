using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    public Animator anim;

    public float iniHealth;
    float currentHealth;

    public int enemyXP;

    public bool death;

    [SerializeField] public enemyHealthbar enemyHB;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = iniHealth;
        death = false;
        enemyHB.UpdateHealthbar(iniHealth, currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        enemyHB.UpdateHealthbar(iniHealth, currentHealth);

        //hurt anim
        anim.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            death = true;
            anim.SetBool("move", false);
            anim.SetBool("dead", true);
        }
    }
    void disableEnemy()
    {
        //player xp
        GameObject p = GameObject.Find("/GameController/Player(Clone)");
        p.GetComponent<playerLife>().playerXP += enemyXP;
        enemyHB.enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
