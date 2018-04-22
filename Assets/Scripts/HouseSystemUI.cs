using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSystemUI : MonoBehaviour {

    CanvasRenderer canvas;
    bool isInputEnabled;
    HouseSystem hs;
    GoldController goldc;

    public PriceText priceText;

    int price; //ugly cost caching


    // Use this for initialization
    void Start() {
        AttachToPlayer();

        canvas = GetComponentInChildren<CanvasRenderer>();
        SetRender(false);
        goldc = GetComponentInParent<GoldController>();
        //priceText = GetComponentInChildren<PriceText>();
    }

    public void injectHouseSystem(HouseSystem houseSystem)
    {
        hs = houseSystem;
    }

    // Update is called once per frame
    void Update() {
        if (isInputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                //print("building X house");
                BuildHouse(WeaponController.Weapons.Sword);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                //print("building C house");
                BuildHouse(WeaponController.Weapons.Pistol);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                //print("building V house");
                BuildHouse(WeaponController.Weapons.Shotgun);
            }
        }
    }

    public void ShowPrice(int cost)
    {
        price = cost;
        if (!goldc.canBuy(price))
        {
            ShowPriceApply();
            ShowTooExpensive();
        }
        else
        {
            ShowPriceApply();
        }
    }

    void ShowPriceApply()
    {
        priceText.SetPriceText(price);
    }

    public void ShowTooExpensive()
    {
        priceText.TooExpensive();
    }

    void BuildHouse(WeaponController.Weapons w)
    {
        if (goldc.canBuy(price))
        {
            goldc.spendGold(price);
            hs.BuildCurrentHouse(w);
        }
        else
        {
            ShowTooExpensive();
        }
    }

    public void SetRender(bool isRendering)
    {
        canvas.gameObject.SetActive(isRendering);
        isInputEnabled = isRendering;
    }

    void AttachToPlayer()
    {
        GameObject player = GameObject.Find("Player");
        transform.parent = player.transform;
    }
}
