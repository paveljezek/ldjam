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

    public int bulletSpeed;
    public GameObject[] bullets;

    // the idiot who left "public" at "weapon" here for debugging should
    //  himself get the fuck rid of it
    public Weapons weapon = Weapons.Staff;
    public const KeyCode ATTACK_BUTTON = KeyCode.RightControl;

    // set to the following type with bullets
    const int nonBulletWeps = (int)Weapons.Pistol;
    const float bulletXOffset = 1f;
    const float bulletSpreadRange = 30f;

    private PlayerPlatformerController playerPlatformer;

    private GameObject toppanel;

    Dictionary<Weapons, int> weaponStats = new Dictionary<Weapons, int>()
    {
        { Weapons.Staff, 1 },
        { Weapons.Sword, 0 },
        { Weapons.Pistol, 0 },
        { Weapons.Shotgun, 0 },
        { Weapons.BFG, 0 }
    };

    void Start () {

        toppanel = GameObject.Find("TopPanel");
        selectWeapon(Weapons.Staff);
        updatePanel();
        playerPlatformer = gameObject.GetComponent<PlayerPlatformerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectWeapon(Weapons.Staff);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectWeapon(Weapons.Sword);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectWeapon(Weapons.Pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectWeapon(Weapons.Shotgun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectWeapon(Weapons.BFG);
        }
        // don't shoot if picking a weapon
        else if (Input.GetKeyDown(ATTACK_BUTTON))
        {
            useWeapon();
        }
    }

	void selectWeapon(Weapons wep) {
        if (wep != weapon && weaponStats[wep] > 0) {
            weapon = wep;
            updatePanel();

            playerPlatformer.setAccordingWeaponAnimation(weapon);
        }
        else
        {
            print("Pojeb si mamu");
        }
	}

	public Weapons getCurrentWeapon() {
		return weapon;
	}

    void useWeapon()
    {
        playerPlatformer.setAnimationState(PlayerPlatformerController.MovementState.Attacking);
        if (weapon <= Weapons.Sword)
        {
            MeleeHandler mhandler = gameObject.GetComponentInChildren<MeleeHandler>();
            if(mhandler.hit()) {
                Collider2D enemy = mhandler.enemy();
                if(enemy.tag == "Enemy") {
                    enemy.gameObject.GetComponent<HealthController>().healthSub(25);
                }
            }

            return;
        }

        SpriteRenderer sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        int direction = -1;
        if (!sr.flipX) direction = 1;

        Vector2 bulletSpawnPos = transform.position;
        bulletSpawnPos.x += direction * bulletXOffset;
        
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

    public void increaseWeaponLevel(Weapons weptype)
    {
        weaponStats[weptype] += 1;
    }

    public void decreaseWeaponLevel(Weapons weptype)
    {
        weaponStats[weptype] -= 1;
    }

    private void updatePanel() {
        toppanel.GetComponentInChildren<WeaponImageChanger>().updateImage(weapon.ToString());
    }
}
