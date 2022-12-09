using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Entities Postitions")]
public class EntitiesPositions : ScriptableObject
{
    public List<OverlayTiles> enemyPositions = new List<OverlayTiles>();
    
    public List<OverlayTiles> playerPositions = new List<OverlayTiles>();
}
