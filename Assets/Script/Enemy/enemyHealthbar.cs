using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthbar : MonoBehaviour
{
    [SerializeField] public Image healthbarSprite;

    public void UpdateHealthbar(float max, float current)
    {
        healthbarSprite.fillAmount = current / max;
    }
}
