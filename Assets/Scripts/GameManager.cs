using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (Input.GetButtonUp(KeyCode.Escape.ToString()))
        {
            Application.Quit();
        }

        if (Input.GetButtonUp(KeyCode.R.ToString()))
        {
            SceneManager.LoadScene("TheoPlaygroundScene");
        }

        
    }

    public void CheckIfPlayerTurnFinished() 
    {
        if (playerPlayedCounter == EntitiesPositions.playerPositions.Count)
        {
            Debug.Log("Tour ennemis");
            playerTurn = false;
            enemyTurn = true;
            playerPlayedCounter = 0;
            enemyPlayedCounter = 0;
        }
    }

    public void CheckIfEnemyTurnFinished() 
    {
        if (enemyPlayedCounter == enemyList.Count)
        {
            Debug.Log("Tour joueur");
            playerTurn = true;
            enemyTurn = false;
            enemyPlayedCounter = 0;
            playerPlayedCounter = 0;
        }
    }
}
