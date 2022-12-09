using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIdle : GameplayIngredients.Logic.LogicBase
{
    
    public override void Execute(GameObject instigator = null)
    {
        Debug.Log("Je suis en idle");
    }
}
