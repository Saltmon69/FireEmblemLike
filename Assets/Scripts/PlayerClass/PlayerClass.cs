using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour
{
    //Variables affichage
    
    public string className;
    public string classDescription;
    
    //Variables statistiques
    
    [HideInInspector] public int life;
    [HideInInspector] public int classAttack;
    [HideInInspector] public int defense;
    [HideInInspector] public int magie;
    [HideInInspector] public int esquive;
    [HideInInspector] public int deplacement;
    
    //Variables compétences

    public SkillClass baseAttack;
    public SkillClass firstSkill;
    public SkillClass secondSkill;
    
    //Variables états

    public bool buff;

    public int TakeDamage(PlayerClass stats, SkillClass skillUsed)
    {
        int damage;
        
        

        return 0;
    }

}
