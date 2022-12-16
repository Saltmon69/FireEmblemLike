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
    public GameManager _GameManager;

    public TextMeshProUGUI name;
    public TextMeshProUGUI pv;
    public TextMeshProUGUI tour;

    private void Update()
    {
        var value = playerHealth.maxhealth / playerHealth.life;
        pv.SetText("PV: " + playerHealth.life.ToString());
        if (_GameManager.enemyTurn)
            tour.SetText("Tour de l'ennemi");
        if(_GameManager.playerTurn)
            tour.SetText("Tour du joueur");
        name.SetText(playerHealth.className);
        healthBar.fillAmount = playerHealth.maxhealth / playerHealth.life;
    }
}
