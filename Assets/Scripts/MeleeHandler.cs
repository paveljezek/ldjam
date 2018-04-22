using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandler : MonoBehaviour {

	private bool canHit = false;
	private Collider2D who;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		canHit = true;
		who = other;
	}

	void OnTriggerExit2D(Collider2D other) {
		canHit = false;
	}

	public bool hit() {
		return canHit;
	}

	public Collider2D enemy() {
		return who;
	}
}
