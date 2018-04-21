using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HouseSystem : MonoBehaviour {

    public TileCollisionHandler tch;
    public HouseSystemUI ui;

    void Start()
    {
        tch.HouseSpotEnabled += OnHouseSpotEnabled;
        tch.HouseSpotDisabled += OnHouseSpotDisabled;

    }

    //called every frame when standing on a spot for house
    private void OnHouseSpotEnabled(object sender, EventArgs e)
    {
        print("HouseSystem: OnHouseSpotEnabled");
        ui.SetRender(true);
    }

    private void OnHouseSpotDisabled(object sender, EventArgs e)
    {
        ui.SetRender(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
