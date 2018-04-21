using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRestartManager : MonoBehaviour {

	public Button btn;
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(restart);
	}
	
	void restart() {
		Application.LoadLevel(Application.loadedLevel);
	}
} 
