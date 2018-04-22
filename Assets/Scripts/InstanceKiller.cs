using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceKiller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger enter");
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponentInParent<HealthController>().healthSub(100);
        } else {
            // kill them with fire
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("on col enter");
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<HealthController>().healthSub(100);
        }
    }
}
