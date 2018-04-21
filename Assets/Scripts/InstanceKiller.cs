using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceKiller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Killing " + other.name + "with freaking fire");
        // kill them with fire
        Destroy(other.gameObject);
    }
}
