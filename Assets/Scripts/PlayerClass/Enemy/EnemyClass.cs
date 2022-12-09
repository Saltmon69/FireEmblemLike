using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : PlayerClass
{
    
    private void Start()
    {
        // Texts
        
        className = "Mailman";

        life = 50f;
        movement = 8;
        dodge = 2f;
        classAttack = 20f;
        defense = 18f;
    }

    private void Update()
    {
        
    }
    
    public override void Movement()
    {
        
    }
}
