using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerStats : MonoBehaviour
{
    [SerializeField] private TMP_Text attackDamage;
    [SerializeField] private TMP_Text totalHealth;
    [SerializeField] private TMP_Text enemiesKilled;
    [SerializeField] private TMP_Text damageTaken;
    [SerializeField] private TMP_Text shortestTime;


    // Update is called once per frame
    void Update()
    {
        SetStats();
    }

    void SetStats()
    {
        if (GameObject.Find("GameController/Player(Clone)") != null)
        {
            playerLife pl = GameObject.Find("GameController/Player(Clone)").GetComponent<playerLife>();
            attackDamage.text = GameObject.Find("GameController/Player(Clone)").GetComponent<playerAttack>().currentAttackDamage.ToString();
            totalHealth.text = pl.playerHealth.ToString();
            enemiesKilled.text = pl.currentPlayerEnemiesKilled.ToString();
            damageTaken.text = pl.currentPlayerDamageTaken.ToString();
            shortestTime.text = GameObject.Find("GameController/Player(Clone)").GetComponent<playerAttack>().topTimer.ToString();
        }
    }
}
