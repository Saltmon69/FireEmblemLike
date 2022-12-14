using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Entities Postitions")]
public class EntitiesPositions : ScriptableObject
{
    public List<CharacterTileInfo> playerPositions = new List<CharacterTileInfo>();
}
