using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyHit : MonoBehaviour {

    private float lastHitTime = 0f;
    HealthController hpControl;

    SpriteRenderer sr;

    float lastDmg = 10;

    void Start()
    {
        hpControl = GetComponentInParent<HealthController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (((lastHitTime + 0.5f) < Time.time) && other.gameObject.tag == "Enemy")
        {
            lastHitTime = Time.time;
            hpControl.healthSub(lastDmg);
            StartCoroutine(ShowTakingDamage());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            lastHitTime = Time.time;
            hpControl.healthSub(lastDmg);
            StartCoroutine(ShowTakingDamage());
        }
    }

    IEnumerator ShowTakingDamage()
    {
        Color orig = Color.white;//spriteRenderer.color;    
        sr.color = Color.red;

        yield return new WaitForSeconds(0.1f + lastDmg / 2000.0f); ;

        sr.color = orig;
        yield return null;
    }
}
