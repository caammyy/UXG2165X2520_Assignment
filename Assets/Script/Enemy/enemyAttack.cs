using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public string weaponID;
    private List<Weapon> weapons;
    public Weapon enemyWeapon;

    public float attackCooldown;
    public float attackRange; 
    public float attackDamage;

    [SerializeField] private BoxCollider2D coll;
    public float collDistance;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator ani;

    private playerLife playerHealth;

    private enemyPatrol enemyPatrol;

    private void Awake()
    {
        SetEnemyWeapon();
        ani = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerSpotted())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                ani.SetTrigger("attack");
            }
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerSpotted();
        }
    }

    private bool PlayerSpotted()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center + transform.right * attackRange * transform.localScale.x * collDistance,
            new Vector3(coll.bounds.size.x * attackRange, coll.bounds.size.y, coll.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<playerLife>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(coll.bounds.center + transform.right * attackRange * transform.localScale.x * collDistance,
            new Vector3(coll.bounds.size.x * attackRange, coll.bounds.size.y, coll.bounds.size.z)); 
    }
    private void DamagePlayer()
    {
        if (PlayerSpotted())
        {
            playerHealth.Hurt(attackDamage);
        }
    }
    void SetEnemyWeapon()
    {
        weapons = Game.GetWeaponList();
        foreach (Weapon w in weapons)
        {
            if (w.weaponID == weaponID)
            {
                enemyWeapon = w;
            }
        }
        attackCooldown = enemyWeapon.weaponAttackRate;
        attackDamage = enemyWeapon.weaponDamageAmount;
        attackRange = enemyWeapon.weaponAttackRange;
        if (enemyWeapon.weaponType == "Melee")
        {
            collDistance = 0.5f;
        }
    }
}
