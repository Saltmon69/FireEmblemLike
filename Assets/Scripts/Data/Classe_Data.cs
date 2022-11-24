using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Classe", order = 2)]
public class Classe_Data : ScriptableObject
{
    public int PV;
    public int PVMAX;
    public int Deplacement;
    public int Esquive;
    public int PlayerAttaque;
    public int Defense;
    public int Magie;
    public int Vitesse;
    public bool Debuf;
    public List<Competence_Data> CompetenceList = new List<Competence_Data>();
}
