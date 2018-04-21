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

	public void enemyKill() {
		addScore(2);
	}

	public void waveComplete() {
		addScore(25);
	}

	public void buildingBuilt() {
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
