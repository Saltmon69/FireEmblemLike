using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Entities Postitions")]
public class EntitiesPositions : ScriptableObject
{
    public List<GameObject> playerPositions = new List<GameObject>();
}
