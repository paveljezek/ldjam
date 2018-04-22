using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class House : MonoBehaviour {

    public HouseSystem hs;
    SpriteRenderer sr;

    public int HealthPoints;
    public int Cost;
    public int Level;

    bool isHouseBuild;

    public WeaponController.Weapons weapon;
    public SpriteRenderer weaponSprite;

    public void BuildHouse()
    {
        if(!isHouseBuild) {
            GameObject panel = GameObject.Find("TopPanel");
            panel.GetComponent<ScoreController>().buildingBuilt();
        }
        isHouseBuild = true;
        sr.enabled = true;
        weaponSprite.enabled = true;

        SetWeapon(WeaponController.Weapons.Pistol);
        
    }

    void SetWeapon(WeaponController.Weapons w)
    {
        weapon = w;

        if(w == WeaponController.Weapons.Sword)
        {
            weaponSprite.sprite = hs.buildings_weaponsSword;
        }
        else if (w == WeaponController.Weapons.Pistol)
        {
            weaponSprite.sprite = hs.buildings_weaponsPistol;
        }
        else if (w == WeaponController.Weapons.Shotgun)
        {
            weaponSprite.sprite = hs.buildings_weaponsShotgun;
        }
    }

    public void DestroyHouse()
    {
        isHouseBuild = false;
        sr.enabled = false;
        weaponSprite.enabled = false;
    }

	// Use this for initialization
	void Start () {
        hs = GameObject.Find("HouseSystem").GetComponent<HouseSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        DestroyHouse();
        //BuildHouse();
    }

    public void SetHouse(int level)
    {
        Level = level;

        //see Holy GDD by Pavel
        switch (level)
        {
            case 1:
                HealthPoints = 30;
                Cost = 100;
                break;
            case 2:
                HealthPoints = 40;
                Cost = 200;
                break;
            case 3:
                HealthPoints = 50;
                Cost = 300;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hs.HouseSpotEnabled(this);
        }

        if (isHouseBuild && other.name.StartsWith("Enemy"))
        {
            HealthPoints -= 5;
            if (HealthPoints <= 0)
                DestroyHouse();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hs.OnHouseSpotDisabled();
        }
    }
}
