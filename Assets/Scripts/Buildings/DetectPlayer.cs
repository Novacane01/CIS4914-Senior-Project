using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("NPC")) {
            // Do calculation math
        }
    }
}
