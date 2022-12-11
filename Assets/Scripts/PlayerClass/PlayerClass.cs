using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour
{
    //Variables affichage
    
    public string className;
    public string classDescription;
    
    //Variables statistiques
    
    [HideInInspector] public float life;
    [HideInInspector] public float classAttack;
    [HideInInspector] public float defense;
    [HideInInspector] public float magie;
    [HideInInspector] public float dodge;
    [HideInInspector] public int movement;
    
    //Variables compétences

    public List<SkillClass> skillList = new List<SkillClass>();

    
    //Variables états

    public bool debuff;
    public bool enemyInRange;
    public bool isEnemy;
    public bool hasMoved;
    public bool hasAttacked;
    
    //Variables range
    
    public CharacterTileInfo _characterTileInfo;
    public RangeFinder _RangeFinder;
    public PathFinder _PathFinder;
    public PlayerClass playerToFocus;
    public SkillClass attack;
    
    
    

    

    public int TakeDamage(SkillClass skillUsed)
    {
        var rndmValue = UnityEngine.Random.Range(0, 6);
        var crit = rndmValue<skillUsed.critChance ? 1.5f : 1f; //var = condition?sitrue:sifalse; --> if concentré
        defense = debuff ? defense -= defense * 0.6f : defense;
        
        var damage = skillUsed.skillAttack * crit - defense * 0.5f;
        var roundedDamage = Mathf.RoundToInt(damage);

        life -= roundedDamage;
        
        return roundedDamage;
    }

    public int Heal(SkillClass skillUsed)
    {
        var healValue = magie * 0.8f;
        var roundedHealValue = Mathf.RoundToInt(healValue);

        life += roundedHealValue;

        return roundedHealValue;
    }

    public void Movement()
    {
        List<OverlayTiles> tilesRange = _RangeFinder.GetTilesInRange(_characterTileInfo.activeTile, movement);
        //List<OverlayTiles> pathfindingTiles = _PathFinder.FindPath()
    }
    

    

}
