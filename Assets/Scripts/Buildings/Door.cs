using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private void OnTriggerEnter (Collider other) {
        if (other.tag.Equals ("NPC")) {
          transform.parent.gameObject.GetComponent<Building>().OnNpcEnter(other);
        }
    }
    private void OnTriggerExit (Collider other) {
        if (other.tag.Equals ("NPC")) {
            transform.parent.gameObject.GetComponent<Building>().OnNpcLeave(other);
        }
    }
}