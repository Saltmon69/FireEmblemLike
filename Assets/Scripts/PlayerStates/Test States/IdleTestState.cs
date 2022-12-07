using System.Collections;
using System.Collections.Generic;
using GameplayIngredients;
using GameplayIngredients.Actions;
using GameplayIngredients.StateMachines;
using UnityEngine;


public class IdleTestState : GameplayIngredients.Logic.LogicBase
{
    public SetStateAction switchToStateA;

    
    
    public override void Execute(GameObject instigator = null)
    {
        GameplayIngredients.Callable.Call(switchToStateA, instigator);
        SwitchState();
    }



    private void SwitchState()
    {
        
        Debug.Log("Je change de state");

    }
    
}

