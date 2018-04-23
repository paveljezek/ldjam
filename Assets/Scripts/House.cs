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

    // should be instead set to weapon type None or something, yet there is no time!
    public WeaponController.Weapons weapon;
    public SpriteRenderer weaponSprite;

    private WeaponController wc;

    public void BuildHouse(WeaponController.Weapons w)
    {
        if(!isHouseBuild) {
            GameObject panel = GameObject.Find("TopPanel");
            panel.GetComponent<ScoreController>().buildingBuilt();
        }
        isHouseBuild = true;
        sr.enabled = true;
        weaponSprite.enabled = true;

        // set weapon if this is the highest tier house built
        int maxLev = hs.findHighestHouseLevelByWepType(w);
        if (maxLev < Level) {
            wc.setWeaponLevel(w, Level);
        }

        SetWeapon(w);
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

        WeaponController.Weapons oldType = weapon;
        weapon = WeaponController.Weapons.Staff;
        // TODO: find highest weapon tier house and asssign it to WeaponController
        int maxLev = hs.findHighestHouseLevelByWepType(oldType);
        if (maxLev == -1)
        {
            wc.setWeaponLevel(oldType, oldType == WeaponController.Weapons.Staff ? 1 : 0); //staff cannot have level lower than 1
        }
        else
        {
            wc.setWeaponLevel(oldType, maxLev);
        }
    }

	// Use this for initialization
	void Start () {
        weapon = WeaponController.Weapons.BFG;
        hs = GameObject.Find("HouseSystem").GetComponent<HouseSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        wc = GameObject.Find("Player").GetComponent<WeaponController>();
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

        Invoke("SetSpriteByLevel", 0.5f);//delay loading (wait for HouseSystem to init)
    }

    void SetSpriteByLevel()
    {
        hs.houseList.Add(this);
        switch (Level)
        {
            case 1:
                sr.sprite = hs.level1;
                break;
            case 2:
                sr.sprite = hs.level2;
                break;
            case 3:
                sr.sprite = hs.level3;
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
