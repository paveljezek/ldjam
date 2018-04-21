using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRestartManager : MonoBehaviour {

	public Button btn;
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(restart);
	}
	
	void restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
} 
