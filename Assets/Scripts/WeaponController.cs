using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {
    public enum Weapons {
        Staff,
        Sword,
        Pistol,
        Shotgun,
        BFG
    }

	public Text weaponText;
	public Image weaponImage;
    public int bulletSpeed;
    public GameObject[] bullets;
    

	Weapons weapon = Weapons.Staff;
    // set to the following type with bullets
    const int nonBulletWeps = (int)Weapons.Pistol;
    // Use this for initialization

    void Start () {

	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            useWeapon();
        }
    }

	void selectWeapon(Weapons wep) {
		weapon = wep;
	}

	Weapons selectedWeapon() {
		return weapon;
	}
	
	void updateWeapon() {
		weaponText.text = weapon.ToString();
	}

    void useWeapon()
    {
        // FIXME: toto dopice odjebat
        weapon = Weapons.Pistol;

        if (weapon < Weapons.Staff)
        {
            print("Fuck you, implement it yourself, I am only doing bullets now.");
            return;
        }

        // position has to be offseted you dumb idiot
        GameObject bullet = Instantiate(bullets[(int)weapon - nonBulletWeps], transform.position, Quaternion.identity);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        Vector2 forceVector = Vector2.zero;
        float bulletSpeed = bullet.GetComponent<BulletController>().speed;
        if (sr.flipX) forceVector.x -= bulletSpeed;
        else forceVector.x += bulletSpeed;
        brb.AddForce(forceVector);
    }
}
