using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceKiller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        // kill them with fire
        Destroy(other.gameObject);
    }
}
