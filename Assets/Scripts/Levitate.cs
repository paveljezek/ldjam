using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour {

    float levitateOffset = 0.1f;
    Vector3 startPos;
    Vector3 direction;
    float speed = 0.2f;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        direction = Vector3.up;

        InvokeRepeating("LevitateMe", Random.Range(0, 1.0f), 0.01f);
	}

    void LevitateMe()
    {
        transform.position += direction * Time.deltaTime * speed;

        if (transform.position.y > startPos.y + levitateOffset)
            direction = Vector3.down;
        if (transform.position.y < startPos.y - levitateOffset)
            direction = Vector3.up;
    }

}
