using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 iniScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator ani;

    private void Awake()
    {
        iniScale = enemy.localScale;
    }
    private void OnDisable()
    {
        ani.SetBool("move", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

   private void DirectionChange()
    {
        ani.SetBool("move", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }


    private void MoveInDirection(int dir)
    {
        idleTimer = 0;
        ani.SetBool("move", true);
        enemy.localScale = new Vector3(Mathf.Abs(iniScale.x) * dir, iniScale.y, iniScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * dir * speed,
            enemy.position.y, enemy.position.z);
    }
}
