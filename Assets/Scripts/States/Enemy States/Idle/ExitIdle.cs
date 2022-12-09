using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitIdle : GameplayIngredients.Logic.LogicBase
{
    public override void Execute(GameObject instigator = null)
    {
        Debug.Log("Je quitte l'idle");
    }
}
