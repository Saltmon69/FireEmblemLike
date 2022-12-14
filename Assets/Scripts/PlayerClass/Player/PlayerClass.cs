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
    public List<PlayerClass> entityInRangeList = new List<PlayerClass>();
    

    //Variables états

    public bool debuff;
    public bool isEnemy;
    public bool hasMoved;
    public bool hasAttacked;
    
    //Variables range
    
    public CharacterTileInfo _characterTileInfo;
    public RangeFinder _RangeFinder;
    public PathFinder _PathFinder;
    public GameManager _GameManager;
    
    
    
    
    
    

    

    public int TakeDamage(SkillClass skillUsed, PlayerClass entitySelected)
    {
        var rndmValue = UnityEngine.Random.Range(0, 6);
        var crit = rndmValue<skillUsed.critChance ? 1.5f : 1f; //var = condition?sitrue:sifalse; --> if concentré
        entitySelected.defense = entitySelected.debuff ? entitySelected.defense -= entitySelected.defense * 0.6f : entitySelected.defense;
        
        var damage = skillUsed.skillAttack * crit - entitySelected.defense * 0.5f;
        var roundedDamage = Mathf.RoundToInt(damage);

        entitySelected.life -= roundedDamage;
        
        return roundedDamage;
    }
    
    public int TakeDamageForRicochet(SkillClass skillUsed, PlayerClass entitySelected)
    {
        var rndmValue = UnityEngine.Random.Range(0, 6);
        var crit = rndmValue<skillUsed.critChance ? 1.5f : 1f; //var = condition?sitrue:sifalse; --> if concentré
        entitySelected.defense = entitySelected.debuff ? entitySelected.defense -= entitySelected.defense * 0.6f : entitySelected.defense;
        
        var damage = skillUsed.skillAttack * crit - entitySelected.defense * 0.5f;
        damage = damage / 2;
        var roundedDamage = Mathf.RoundToInt(damage);

        entitySelected.life -= roundedDamage;
        
        return roundedDamage;
    }

    public int Heal(SkillClass skillUsed)
    {
        var healValue = magie * 0.8f;
        var roundedHealValue = Mathf.RoundToInt(healValue);

        life += roundedHealValue;

        return roundedHealValue;
    }

}
