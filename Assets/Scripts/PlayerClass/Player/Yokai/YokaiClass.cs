using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokaiClass : PlayerClass
{

    
    
    public int turnCounter;
    
    void Start()
    {
        _GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _characterTileInfo = GetComponent<CharacterTileInfo>();
        maxhealth = 50;
        monstre = true;
        oldLife = 50;
        
        if (monstre)
        {
            life = oldLife;
            magie = 20;
            classAttack = 10;
            defense = 8;
            dodge = 1;
            movement = 8;
        }

        if (poupee)
        {
            life = 1;
            magie = 1;
            classAttack = 1;
            defense = 1;
            dodge = 2;
            movement = 0;
        }


        
        
    }

    
    void Update()
    {
        if (hasAttacked)
        {
            if (poupee)
            {
                turnCounter++;
            }
            
        }
        
        if (poupee && life <= 0)
        {
            monstre = true;
            turnCounter = 0;
        }

        if (turnCounter == 2)
        {
            monstre = true;
            turnCounter = 0;
        }
    }
}
