using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthbar : MonoBehaviour
{
    public playerLife playerHealth;
    public string playerName;
    [SerializeField] private Image totalHp;
    [SerializeField] private Image currentHp;

    private void Start()
    {
        if (playerHealth != null)
            totalHp.fillAmount = playerHealth.playerHealth / playerHealth.playerHealth;
    }
    private void Update()
    {
        if (playerHealth != null)
        currentHp.fillAmount = playerHealth.currentHealth / playerHealth.playerHealth;
    }
}
