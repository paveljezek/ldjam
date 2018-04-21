using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HouseSystem : MonoBehaviour {

    public TileCollisionHandler tch;
    public HouseSystemUI ui;

    House currentHouse;

    void Start()
    {
        ui.injectHouseSystem(this);
    }

    public void BuildCurrentHouse()
    {
        currentHouse.BuildHouse();
    }

    public void HouseSpotEnabled(House house)
    {
        ui.SetRender(true);
        currentHouse = house;
    }


    public void OnHouseSpotDisabled()
    {
        ui.SetRender(false);
    }
}
