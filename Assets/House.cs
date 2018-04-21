using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class House : MonoBehaviour {

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
        sr = GetComponentInChildren<SpriteRenderer>();
        //DestroyHouse();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
