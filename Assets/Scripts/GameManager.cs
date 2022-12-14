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
}
