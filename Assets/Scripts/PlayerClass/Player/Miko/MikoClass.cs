using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoClass : PlayerClass
{
    
    void Start()
    {
        _GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _characterTileInfo = GetComponent<CharacterTileInfo>();
        magie = 20;
        classAttack = magie;
        defense = 8;
        dodge = 1;
        movement = 8;
    }

    private void Update()
    {
        if (hasAttacked)
            _GameManager.playerPlayedCounter++;
    }
}
