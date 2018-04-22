using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImageChanger : MonoBehaviour {


	public Sprite staff, sword, pistol, shotgun;

	public Dictionary<string, Sprite> weapons = new Dictionary<string, Sprite>() {
		{"Staff", null},
		{"Sword", null},
		{"Pistol", null},
		{"Shotgun", null}
	};
	// Use this for initialization
	void Start () {
		weapons["Staff"] = staff;
		weapons["Sword"] = sword;
		weapons["Pistol"] = pistol;
		weapons["Shotgun"] = shotgun;
		
	}
	
	public void updateImage(string weapon) {
		gameObject.GetComponentInChildren<Text>().text = weapon;
		gameObject.GetComponent<Image>().sprite = weapons[weapon];
	}
	
}
