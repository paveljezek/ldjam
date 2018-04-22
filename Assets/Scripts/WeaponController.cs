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

    // the idiot who left "public" at "weapon" here for debugging should
    //  himself get the fuck rid of it
    public Weapons weapon = Weapons.Staff;
    // set to the following type with bullets
    const int nonBulletWeps = (int)Weapons.Pistol;
    const float bulletXOffset = 1f;
    const float bulletSpreadRange = 30f;
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
        if (weapon < Weapons.Staff)
        {
            print("Fuck you, implement it yourself, I am only doing bullets now.");
            return;
        }

        SpriteRenderer sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        int direction = -1;
        if (!sr.flipX) direction = 1;

        Vector2 bulletSpawnPos = transform.position;
        bulletSpawnPos.x += direction * bulletXOffset;

        // position has to be offseted you dumb idiot
        int numBullets = 1;
        if (weapon == Weapons.Shotgun) numBullets = 2;

        for(int i = 0; i < numBullets; i++) {
            bulletSpawnPos.y += 0.2f * i;
            GameObject bullet = Instantiate(bullets[(int)weapon - nonBulletWeps], bulletSpawnPos, Quaternion.identity);
            float bulletSpeed = bullet.GetComponent<BulletController>().speed;
            Vector2 forceVector = new Vector2(bulletSpeed * direction, 0);
            Vector2 randomizer = new Vector2(
                Random.Range(-bulletSpreadRange, bulletSpreadRange),
                Random.Range(-bulletSpreadRange, bulletSpreadRange)
            );

            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
            brb.AddForce(
                forceVector + randomizer 

            );
        }
    }
}
