using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {

	public Text weaponText;
	public Image weaponImage;

	public string[] weapons = {"staff", "sword", "pistol", "shotgun", "bfg"};
	// Use this for initialization
	void Start () {
		updateWeapon(1);
	}
	
	void updateWeapon(int index) {
		weaponText.text = weapons[index];
	}
}
