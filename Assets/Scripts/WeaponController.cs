using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {

	public Text weaponText;
	public Image weaponImage;

	public string[] weapons = {"staff", "sword", "pistol", "shotgun", "bfg"};
	int weapon;
	// Use this for initialization
	void Start () {
		weapon = 0;
		updateWeapon();
	}

	void selectWeapon(int index) {
		weapon = index;
		updateWeapon();
	}

	int selectedWeapon() {
		return weapon;
	}
	
	void updateWeapon() {
		weaponText.text = weapons[weapon];
	}
}
