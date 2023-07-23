using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator anim;
    public int animatorWeapon;
    public Transform attackPoint;

    public Weapon playerWeapon;

    public float currentAttackDamage; 
    public float currentAttackRange;
    public float currentAttackRate;
    public string currentWeaponType;

    public LayerMask enemyLayer;


    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        SetPlayerWeapon(); 

        if (Time.time >= nextAttackTime)
        {
            if (playerWeapon.weaponType == "Melee")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //animation
                    anim.SetTrigger("attack");
                    anim.SetInteger("weapon", animatorWeapon);
                    //MeleeAttack();
                    nextAttackTime = Time.time + 1f / currentAttackRate;
                }
            }
        }
        
    }
    void MeleeAttack()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, currentAttackRange, enemyLayer);
        
        //damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyLife>().TakeDamage(currentAttackDamage);
            if (enemy.GetComponent<enemyLife>().death)
            {
                GetComponent<playerLife>().currentPlayerEnemiesKilled += 1;
                GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().noOfEnemies -= 1;
            }
        }
        
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, currentAttackRange);
    }

    void SetPlayerWeapon()
    {
        currentAttackRange = playerWeapon.weaponAttackRange;
        currentAttackRate = playerWeapon.weaponAttackRate;
        currentWeaponType = playerWeapon.weaponType;
    }
}
