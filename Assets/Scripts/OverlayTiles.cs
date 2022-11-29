using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayTiles : MonoBehaviour
{
    public int G;
    public int H;
    public int F
    {
        get { return G + H; }
    }

    public bool isBlocked;

    public OverlayTiles previous;

    public Vector3Int gridLocation;

    public GameObject characterOnTile;
    
    void Update() {
        
    }

    public void ShowTile()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
    public void HideTile()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
}
