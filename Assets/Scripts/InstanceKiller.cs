using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceKiller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player") {
            other.gameObject.GetComponent<HealthController>().healthSub(100);
        } else {
            // kill them with fire
            Destroy(other.gameObject);
        }
    }
}
