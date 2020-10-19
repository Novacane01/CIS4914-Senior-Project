using System.Collections.Generic;
using System.Linq;
using UnityEngine;

abstract public class Building : MonoBehaviour {
    protected List<NPC> occupancy = new List<NPC>();

    public void calculateSpread() {
        List<NPC> infected = occupancy.FindAll(npc => npc.isInfected).ToList();
        int numInfected = infected.Count;
        System.Random rnd = new System.Random();
        foreach (NPC npc in occupancy) {
            float r = rnd.Next(100) / 100f;
            float t = 1 - Mathf.Pow(1 - Disease.infectionRate, numInfected);
            if (r <= t && !npc.isInfected) {
                NPCManager.numInfected++;
                npc.isInfected = true;
                Debug.Log(string.Format("{0} people have contracted chlamydia", NPCManager.numInfected));
            }
        }
    }

    abstract public void OnNpcEnter(Collider other);
    abstract public void OnNpcLeave(Collider other);
}