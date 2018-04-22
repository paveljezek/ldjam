using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	public SimpleHealthBar healthBar = null;
	public Canvas endCanvas;

    // Use this for initialization
    public float maxHealth = 100;
    private float health;

    void Start () {
        health = maxHealth;
        updateHealth();
	}
	
	public void healthAdd(float amount) {
		health = health + amount > 100 ? 100 : health + amount;
		updateHealth();
	}

	public void healthSub(float amount) {
		health -= amount;
		updateHealth();
        if (health <= 0)
        {
            // healthBar == null if this is not a player
            if (healthBar != null)
            {
                endCanvas.GetComponent<EndStateController>().triggerEndState();
            }
            else {
                print("destroy " + gameObject.name);
                Destroy(gameObject);
            }
        }
	}

    void updateHealth() {
        if (healthBar != null) {
		    healthBar.UpdateBar(health, maxHealth);
        }
    }
    
}
