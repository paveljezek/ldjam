using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float damage = 10;
    public float speed = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            HealthController hc = other.gameObject
                .GetComponent<HealthController>();

            hc.healthSub(damage);
        }
        // Good bye, cruel world! I'm getting the F outta here
        Destroy(gameObject);
    }
}
