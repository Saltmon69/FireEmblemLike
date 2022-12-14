using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerTurn;
    public bool enemyTurn;

    public List<PlayerClass> enemyList = new List<PlayerClass>();

    public int enemyPlayedCounter;
    public int playerPlayedCounter;


    private void Start()
    {
        enemyPlayedCounter = 0;
        playerPlayedCounter = 0;

        playerTurn = true;
        enemyTurn = false;
    }


    private void Update()
    {
        if (playerPlayedCounter == 4)
        {
            enemyTurn = true;
            playerTurn = false;
            playerPlayedCounter = 0;
        }

        if (enemyPlayedCounter == enemyList.Count)
        {
            playerTurn = true;
            enemyTurn = false;
            enemyPlayedCounter = 0;
        }
    }
}
