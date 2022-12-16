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

    public EntitiesPositions EntitiesPositions;


    private void Start()
    {
        enemyPlayedCounter = 0;
        playerPlayedCounter = 0;

        playerTurn = true;
        enemyTurn = false;
    }


    private void Update()
    {
        

        
    }

    public void CheckIfPlayerTurnFinished() {
        if (playerPlayedCounter == EntitiesPositions.playerPositions.Count)
        {
            playerTurn = false;
            enemyTurn = true;
            playerPlayedCounter = 0;
            enemyPlayedCounter = 0;
        }
    }

    public void CheckIfEnemyTurnFinished() {
        if (enemyPlayedCounter == enemyList.Count)
        {
            playerTurn = true;
            enemyTurn = false;
            enemyPlayedCounter = 0;
            playerPlayedCounter = 0;

            for(var i = 0; i < EntitiesPositions.playerPositions.Count; i++)
            {
                EntitiesPositions.playerPositions[i].GetComponent<PlayerClass>().hasAttacked = false;
                EntitiesPositions.playerPositions[i].GetComponent<PlayerClass>().hasMoved = false;
            }

        }
    }
}
