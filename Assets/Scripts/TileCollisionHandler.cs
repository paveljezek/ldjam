using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TileCollisionHandler : MonoBehaviour {

    Tilemap tilemap;
    Vector3Int pPos;

    public string HouseSpotTileName;

    // Use this for initialization
    void Start () {
        tilemap = GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
