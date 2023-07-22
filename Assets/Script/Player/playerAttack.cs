using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int attackDamage = 2;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private int noOfEnemiesKilled = 0;
    private int currentStageEnemies = 3;

    public int noOfStagesCompleted = 0;

    private GameObject wall;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {
        //animation
        anim.SetTrigger("attack");
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        //damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyLife>().TakeDamage(attackDamage);
            if (enemy.GetComponent<enemyLife>().death)
            {
                noOfEnemiesKilled += 1;
                currentStageEnemies -= 1;
                foreach (var gObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    string wallname = "Wall_" + noOfStagesCompleted;
                    if (gObj.name.Contains(wallname))
                    {

                        wall = gObj;
                    }
                }
                if (currentStageEnemies == 0)
                {
                    Destroy(wall.gameObject);
                    noOfStagesCompleted += 1;
                    currentStageEnemies = 3;
                }
            }
        }
        
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
