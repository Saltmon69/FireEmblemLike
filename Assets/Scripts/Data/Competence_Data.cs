using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Competence", order = 1)]

public class Competence_Data : ScriptableObject
{
    public int PP;
    public int CompAttaque;
    public int Critique;
    public GameObject ZoneAction;
}
