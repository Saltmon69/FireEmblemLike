using System.Collections;
using System.Collections.Generic;
using GameplayIngredients.Actions;
using UnityEngine;

public class EnterIdle : GameplayIngredients.Logic.LogicBase
{
    public SetStateAction setToIdle;
    
    public override void Execute(GameObject instigator = null)
    {
        setToIdle.Execute();
        Debug.Log("Je rentre en idle");
    }
}
