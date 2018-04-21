using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateController : MonoBehaviour {

	public GameObject container;
	// Use this for initialization
	void Start () {
		
	}
	
	public void triggerEndState() {
		container.SetActive(true);
		
	}
	
}
