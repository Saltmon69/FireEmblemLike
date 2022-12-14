using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinClass : PlayerClass
{
    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
