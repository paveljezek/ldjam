using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyHit : MonoBehaviour {

    private float lastHitTime = 0f;
    HealthController hpControl;

    void Start()
    {
        hpControl = GetComponentInParent<HealthController>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (((lastHitTime + 0.5f) < Time.time) && other.gameObject.tag == "Enemy")
        {
            lastHitTime = Time.time;
            hpControl.healthSub(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            lastHitTime = Time.time;
            hpControl.healthSub(10);
        }
    }
}
