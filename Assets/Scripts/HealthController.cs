using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	public SimpleHealthBar healthBar;

	public Canvas endCanvas;
	
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
		if(health <= 0) {
			endCanvas.GetComponent<EndStateController>().triggerEndState();
		}
		updateHealth();
	}

	void updateHealth() {
		healthBar.UpdateBar(health, maxHealth);
	}
}
