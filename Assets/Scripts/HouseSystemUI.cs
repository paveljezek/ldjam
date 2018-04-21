using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSystemUI : MonoBehaviour {

    CanvasRenderer canvas;
    bool isInputEnabled;
    HouseSystem hs;
    GoldController goldc;

	// Use this for initialization
	void Start () {
        AttachToPlayer();

        canvas = GetComponentInChildren<CanvasRenderer>();
        SetRender(false);
        goldc = GetComponentInParent<GoldController>();
    }

    public void injectHouseSystem(HouseSystem houseSystem)
    {
        hs = houseSystem;
    }
	
	// Update is called once per frame
	void Update () {
        if (isInputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                print("building X house");
                BuildX();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                print("building C house");
                BuildX();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                print("building V house");
                BuildX();
            }
        }
    }

    void BuildX()
    {
        if (goldc.RequestPurchase())
        {
            hs.BuildCurrentHouse();
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
