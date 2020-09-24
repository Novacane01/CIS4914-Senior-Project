using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    int currentPopulation;
    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("NPC")) {
            other.gameObject.GetComponent<NPC>().startTask();
            other.gameObject.GetComponent<NPC>().meshRenderer.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("NPC")) {
            other.gameObject.GetComponent<NPC>().meshRenderer.enabled = true;
        }
    }
}
