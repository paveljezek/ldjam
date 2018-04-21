using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollisionHandler : MonoBehaviour {

    public Tilemap tilemap;
    Vector3Int pPos;

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
            pPos = tilemap.WorldToCell(collision.rigidbody.position);
            Debug.Log("pPos:" + pPos);
        }

    }
}
