using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TileCollisionHandler : MonoBehaviour {

    Tilemap tilemap;
    Vector3Int pPos;

    public string HouseSpotTileName;

    public event EventHandler HouseSpotEnabled;
    public event EventHandler HouseSpotDisabled;


    void EnableHouseSpot()
    {
        if (HouseSpotEnabled != null)
            HouseSpotEnabled(this, EventArgs.Empty);
    }

    void DisableHouseSpot()
    {
        if (HouseSpotDisabled != null)
            HouseSpotDisabled(this, EventArgs.Empty);
    }


    // Use this for initialization
    void Start () {
        tilemap = GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Detecting the Grid Position of Player
        if (collision.gameObject.name == "Player")
        {
            //print(collision.rigidbody.position);
            Vector2 adjustedPos = collision.rigidbody.position - Vector2.up;
            adjustedPos -= Vector2.right;
            pPos = tilemap.WorldToCell(adjustedPos);
            //Debug.Log("pPos:" + pPos);
            Sprite s = tilemap.GetSprite(pPos);
            //print(s);
            if (s == null)
                return;
            if (s.name == HouseSpotTileName)
            {
                //print("Standing on a spot for house");
                EnableHouseSpot();
            }
            else if (s.name != HouseSpotTileName)
            {
                DisableHouseSpot();
            }
        }

    }
}
