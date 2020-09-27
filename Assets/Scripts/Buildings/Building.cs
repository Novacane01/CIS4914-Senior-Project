using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    List<NPC> occupancy = new List<NPC>();
    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("NPC")) {
            NPC npc = other.gameObject.GetComponent<NPC>();
            npc.startTask();
            occupancy.Add(npc);
            Disease.calculateSpread(occupancy);
            other.gameObject.GetComponent<NPC>().meshRenderer.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("NPC")) {
            other.gameObject.GetComponent<NPC>().meshRenderer.enabled = true;
        }
    }
}
