using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaClass : PlayerClass
{
    private void Start()
    {
        
        //Texts

        className = "Yakuza";
        classDescription =
            "L'un des plus puissants chefs de gang, sa peur et sa haine pour les Corrompus l'a poussé à rejoindre vos rangs.";
        
        //Stats
        
        life = 35f;
        classAttack = 20f;
        defense = 12f;
        magie = 10f;
        dodge = 2f;
        movement = 6;
        isEnemy = false;

        //Scripts
        _GameManager= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        
    }
}
