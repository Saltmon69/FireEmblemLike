using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public PlayerClass playerHealth;

    public TextMeshProUGUI textMesh;


    private void Update()
    {
        textMesh.SetText(playerHealth.className);
        healthBar.fillAmount = playerHealth.maxhealth / playerHealth.life;
    }
}
