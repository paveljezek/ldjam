using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour {


	public Text goldText;

	private int gold;
	// Use this for initialization
	void Start () {
		gold = 0;
		updateGold();
	}

    public bool RequestPurchase()
    {
        return true;//always enough gold :)
    }

	public void enemyKill() {
		goldAdd(5);
	}

	public bool canBuy(int amount) {
		return gold - amount >= 0;
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
