using System.Collections;
using System.Collections.Generic;using UnityEditor.Compilation;
using UnityEngine;

public abstract class SkillClass : MonoBehaviour
{
    public int PP;
    public float skillAttack;
    public int critChance;

    public List<PlayerClass> enemyList = new List<PlayerClass>();
    
    /*
     * La liste va servir a obtenir la liste des enemy dans la range pour les attaques faisant des dégâts à plusieurs
     * ennemis en même temps. Peut être qu'un dictionnaire permettrait d'assigner un token à un ennemi.
     *
     * Donne ton avis ici ou sur discord psq j'ai vraiment un doute de la démarche
     */
    
    // Variables attack range
}
