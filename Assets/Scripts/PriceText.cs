using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceText : MonoBehaviour {

    Text text;
    Color sCol;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        sCol = text.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPriceText(int price)
    {
        text.color = sCol;
        text.text = price + " gold";
    }

    internal void TooExpensive()
    {
        text.color = Color.red;
    }
}
