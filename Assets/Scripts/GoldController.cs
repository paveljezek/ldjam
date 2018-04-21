using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour {


	public Text goldText;

	int gold;
	// Use this for initialization
	void Start () {
		gold = 0;
		updateGold();
	}

    public bool RequestPurchase()
    {
        return true;//always enough gold :)
    }
	
	void goldAdd(int amount) {
		gold += amount;
		updateGold();
	}

	void goldSub(int amount) {
		gold -= amount;
		updateGold();
	}

	void updateGold() {
		goldText.text = "GOLD: " + gold;
	}
}
