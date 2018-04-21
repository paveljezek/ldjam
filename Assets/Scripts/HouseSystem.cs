using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HouseSystem : MonoBehaviour {

    public TileCollisionHandler tch;
    public HouseSystemUI ui;

    void Start()
    {

    }

    public void HouseSpotEnabled()
    {
        ui.SetRender(true);
    }


    public void OnHouseSpotDisabled()
    {
        ui.SetRender(false);
    }
}
