using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SkillClass : MonoBehaviour
{
    public int PP;
    public float skillAttack;
    public int critChance;
    public int attackRange;

    
    
    // Range et détection
    
    public PlayerClass playerPos;
    
    public MouseCursor _mouseCursor;

    public abstract void Action();








}
