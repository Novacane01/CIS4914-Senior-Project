using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    Building building;  
    void Start() {
        building = GetComponentInParent<Building>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("NPC")) {
            building.OnNpcEnter(other);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("NPC")) {
            building.OnNpcLeave(other);
        }
    }
}