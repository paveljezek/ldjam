using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSystemUI : MonoBehaviour {

    CanvasRenderer canvas;

	// Use this for initialization
	void Start () {
        AttachToPlayer();

        canvas = GetComponentInChildren<CanvasRenderer>();
        SetRender(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetRender(bool isRendering)
    {
        canvas.gameObject.SetActive(isRendering);
    }

    void AttachToPlayer()
    {
        GameObject player = GameObject.Find("Player");
        transform.parent = player.transform;
    }
}
