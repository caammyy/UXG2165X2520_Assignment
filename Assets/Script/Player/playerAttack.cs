using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ashley
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

    public float topTimer;
    public float zoneTimer;
    public bool startZoneTimer = false;


    float nextAttackTime = 0f;

    // Update is called once per frame

    private void Start()
    {
        topTimer = 0f;
        zoneTimer = 0f;
}
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
        if (startZoneTimer)
        {
            zoneTimer += Time.deltaTime;
        }
        else
        {
            if (topTimer == 0f && zoneTimer > 0f)
            {
                topTimer = zoneTimer;

            }
            else if (zoneTimer < topTimer)
            {
                topTimer = zoneTimer;
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
            if (GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().noOfEnemies == 3 && !startZoneTimer)
            {

                zoneTimer = 0f;
                startZoneTimer = true;
            }
            enemy.GetComponent<enemyLife>().TakeDamage(currentAttackDamage);
            if (enemy.GetComponent<enemyLife>().death)
            {
                GetComponent<playerLife>().currentPlayerEnemiesKilled += 1;
                GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().noOfEnemies -= 1;
            }
            if (GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().noOfEnemies == 0)
            {
                startZoneTimer = false;
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
