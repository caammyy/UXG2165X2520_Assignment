using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthbar : MonoBehaviour
{
    [SerializeField] private playerLife playerHealth;
    [SerializeField] private Image totalHp;
    [SerializeField] private Image currentHp;

    private void Start()
    {
        totalHp.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currentHp.fillAmount = playerHealth.currentHealth /10;
    }
}
