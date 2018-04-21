using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class House : MonoBehaviour {

    public HouseSystem hs;

    bool isHouseBuild;

    public void BuildHouse()
    {
        isHouseBuild = true;
        sr.enabled = true;
    }

    public void DestroyHouse()
    {
        isHouseBuild = false;
        sr.enabled = false;
    }


    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        hs = GameObject.Find("HouseSystem").GetComponent<HouseSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        DestroyHouse();
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hs.OnHouseSpotDisabled();
        }
    }
}
