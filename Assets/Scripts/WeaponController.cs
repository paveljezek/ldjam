using System;
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

    private Animator animator;

    public int bulletSpeed;
    public GameObject[] bullets;

    // the idiot who left "public" at "weapon" here for debugging should
    //  himself get the fuck rid of it
    public Weapons weapon = Weapons.Staff;
    public const KeyCode ATTACK_BUTTON = KeyCode.E;

    // set to the following type with bullets
    const int nonBulletWeps = (int)Weapons.Pistol;
    const float bulletXOffset = 0.7f;
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
        animator = GetComponentInChildren<Animator>();

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
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            nextWeapon();
        }
        // don't shoot if picking a weapon
        else if (Input.GetKeyDown(ATTACK_BUTTON))
        {
            useWeapon();
        }
    }

    private void nextWeapon()
    {
        int weaponNumber = (int) getCurrentWeapon();
        var weaponsCount = Enum.GetNames(typeof(Weapons)).Length;
        do
        {
            weaponNumber = (weaponNumber + 1) % weaponsCount;
            print("Trying: " + weaponNumber + "stat" + weaponStats[(Weapons)weaponNumber]);
        } while (weaponStats[(Weapons)weaponNumber] == 0);
        
        print("Selecting: " + weaponNumber);
        selectWeapon((Weapons)weaponNumber);
    }

    void selectWeapon(Weapons wep) {
        if (wep != weapon && weaponStats[wep] > 0) {
            weapon = wep;
            updatePanel();

            switch (wep)
            {
                case Weapons.Staff:
                    animator.SetTrigger("use" + wep.ToString());
                    break;
                case Weapons.Sword:
                    animator.SetTrigger("use" + wep.ToString());
                    break;
                case Weapons.Pistol:
                    animator.SetTrigger("use" + wep.ToString());
                    break;
                case Weapons.Shotgun:
                    animator.SetTrigger("use" + wep.ToString());
                    break;
            }
            //playerPlatformer.setAccordingWeaponAnimation(weapon);
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
        //playerPlatformer.setAnimationState(PlayerPlatformerController.MovementState.Attacking);
        animator.SetTrigger("Attack");

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
        // coordinate bullet spawn with the sprite
        bulletSpawnPos.y -= 0.3f;
        
        int numBullets = 1;
        if (weapon == Weapons.Shotgun) numBullets = 2;

        for(int i = 0; i < numBullets; i++) {
            bulletSpawnPos.y += 0.2f * i;
            GameObject bullet = Instantiate(bullets[(int)weapon - nonBulletWeps], bulletSpawnPos, Quaternion.identity);
            float bulletSpeed = bullet.GetComponent<BulletController>().speed;
            Vector2 forceVector = new Vector2(bulletSpeed * direction, 0);
            Vector2 randomizer = new Vector2(
                UnityEngine.Random.Range(-bulletSpreadRange, bulletSpreadRange),
                UnityEngine.Random.Range(-bulletSpreadRange, bulletSpreadRange)
            );

            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
            brb.AddForce(
                forceVector + randomizer 

            );
        }
    }

    public void setWeaponLevel(Weapons wt, int level)
    {
        if (level == 0)
        {
            // TODO: equip highest usable weapon
            selectWeapon(Weapons.Staff);
        }
        print("Setting weapon " + wt + " ---- level " + level);
        weaponStats[wt] = level;
    }

    private void updatePanel() {
        toppanel.GetComponentInChildren<WeaponImageChanger>().updateImage(weapon.ToString());
    }
}
