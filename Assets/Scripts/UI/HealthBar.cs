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

    public TextMeshProUGUI name;
    public TextMeshProUGUI pv;

    private void Update()
    {
        var value = playerHealth.maxhealth / playerHealth.life;
        pv.SetText("PV: " + playerHealth.life.ToString());
        name.SetText(playerHealth.className);
        healthBar.fillAmount = playerHealth.maxhealth / playerHealth.life;
    }
}
