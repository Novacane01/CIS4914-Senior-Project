using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    List<NPC> occupancy = new List<NPC> ();

    public void OnNpcEnter (Collider other) {
        NPC npc = other.gameObject.GetComponent<NPC> ();
        npc.startTask ();
        Disease.calculateSpread (occupancy);
        occupancy.Add (npc);
        other.gameObject.GetComponent<NPC> ().meshRenderer.enabled = false;
    }
    public void OnNpcLeave (Collider other) {
        other.gameObject.GetComponent<NPC> ().meshRenderer.enabled = true;
    }

}