using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTileInfo : MonoBehaviour
{
    public OverlayTiles activeTile;
    private LayerMask _layer;

    private void Awake()
    {
        _layer = LayerMask.NameToLayer("Tiles");
    }

    public void Update()
    {
        if(activeTile != null) return;
        
        var focusedTileHit = CheckTileBelow();

        if (focusedTileHit.HasValue)
        {
            activeTile = focusedTileHit.Value.collider.gameObject.GetComponent<OverlayTiles>();
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = activeTile.gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
            activeTile.characterOnTile = this.gameObject;
        }
        
    }

    public RaycastHit? CheckTileBelow()
    {
        Ray characterPos = new Ray(transform.position, Vector3.down);
        // Debug.Log(mousePos);
        RaycastHit[] hits = Physics.RaycastAll(characterPos, Mathf.Infinity);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

}
