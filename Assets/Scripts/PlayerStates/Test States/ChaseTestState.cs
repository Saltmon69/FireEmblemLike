using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTestState : GameplayIngredients.Logic.LogicBase
{
    public override void Execute(GameObject instigator = null)
    {
        MessageTest();
    }

    public void MessageTest()
    {
        Debug.Log("J'ai switch de state");
    }
}
