using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HouseSystem : MonoBehaviour {

    public TileCollisionHandler tch;
    public HouseSystemUI ui;

    public Sprite buildings_weaponsSword;
    public Sprite buildings_weaponsPistol;
    public Sprite buildings_weaponsShotgun;

    House currentHouse;

    void Start()
    {
        ui.injectHouseSystem(this);
    }

    public void BuildCurrentHouse(WeaponController.Weapons w)
    {
        currentHouse.BuildHouse(w);
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
