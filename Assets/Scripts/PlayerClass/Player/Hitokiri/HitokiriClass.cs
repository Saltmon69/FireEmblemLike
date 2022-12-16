using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitokiriClass : PlayerClass
{
   
    void Start()
    {
        _GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _characterTileInfo = GetComponent<CharacterTileInfo>();
        maxhealth = 25;
        magie = 2;
        classAttack = 25;
        defense = 10;
        dodge = 3;
        movement = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAttacked)
            _GameManager.playerPlayedCounter++;
    }
}
