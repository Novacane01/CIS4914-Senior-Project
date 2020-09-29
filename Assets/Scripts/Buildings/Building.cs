using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    List<NPC> occupancy = new List<NPC>();

    public void OnNpcEnter(Collider other) {
        NPC npc = other.gameObject.GetComponent<NPC>();
        if (npc.tasks.Peek().location.position == transform.position) {
            npc.startTask();
            Disease.calculateSpread(occupancy);
            occupancy.Add(npc);
            npc.meshRenderer.enabled = false;
        }
    }
    public void OnNpcLeave(Collider other) {
        NPC npc = other.gameObject.GetComponent<NPC>();
        if (npc.tasks.Peek().location.position == transform.position) {
            npc.meshRenderer.enabled = true;
        }
    }
}