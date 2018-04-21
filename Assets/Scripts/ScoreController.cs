using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;

	int score;
	// Use this for initialization
	void Start () {
		score = 0;
		updateScore();
	}

	void enemyKill() {
		addScore(2);
	}

	void waveComplete() {
		addScore(25);
	}

	void buildingBuilt() {
		addScore(50);
	}
	
	private void addScore(int amount) {
		score += amount;
		updateScore();
	}

	void updateScore() {
		scoreText.text = "SCORE: " + score;
	}
}
