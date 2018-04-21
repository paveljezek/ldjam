using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HouseSystem : MonoBehaviour {

    public TileCollisionHandler tch;
    void Start()
    {
        tch.HouseSpotEnabled += OnHouseSpotEnabled;
    }

    //called every frame when standing on a spot for house
    private void OnHouseSpotEnabled(object sender, EventArgs e)
    {
        print("HouseSystem: OnHouseSpotEnabled");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
