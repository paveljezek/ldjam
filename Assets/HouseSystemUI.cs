using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSystemUI : MonoBehaviour {

    CanvasRenderer canvas;
    bool isInputEnabled;

	// Use this for initialization
	void Start () {
        AttachToPlayer();

        canvas = GetComponentInChildren<CanvasRenderer>();
        SetRender(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isInputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                print("building X house");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                print("building C house");
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                print("building V house");
            }
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
