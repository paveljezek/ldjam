using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public SimpleHealthBar healthBar;
	// Use this for initialization
	float health;
	const float maxHealth = 100;

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
	}

	void updateHealth() {
		healthBar.UpdateBar(health, maxHealth);
	}
}
