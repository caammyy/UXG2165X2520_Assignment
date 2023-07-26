using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyHealthbar : MonoBehaviour
{
    [SerializeField] public Image healthbarSprite;
    [SerializeField] public TMP_Text health;

    public void UpdateHealthbar(float max, float current)
    {
        healthbarSprite.fillAmount = current / max;
        health.text = Mathf.Clamp((Mathf.Round(current * 10.0f) * 0.1f), 0, max).ToString();
    }
}
