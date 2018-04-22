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

    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    House currentHouse;

    public List<House> houseList;

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
        ui.ShowPrice(currentHouse.Cost);
    }


    public void OnHouseSpotDisabled()
    {
        ui.SetRender(false);
    }

    public int findHighestHouseLevelByWepType(WeaponController.Weapons weptype)
    {
        int highestLevel = -1;
        foreach (House h in houseList)
        {
            if (h.weapon == weptype && h.Level > highestLevel)
            {
                highestLevel = h.Level;
            }
        }
        return highestLevel;
    }
}
