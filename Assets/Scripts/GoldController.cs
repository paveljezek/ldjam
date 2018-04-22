using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour {


	public Text goldText;

	private int gold;
	// Use this for initialization
	void Start () {
		gold = 200;
		updateGold();
	}

    public bool canBuyAlwaysCheat()
    {
        return true;//always enough gold :)
    }

	public void enemyKill() {
		goldAdd(12);
	}

	public bool canBuy(int amount) {
		return gold - amount >= 0;
	}

	public void spendGold(int amount) {
		goldSub(amount);
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
