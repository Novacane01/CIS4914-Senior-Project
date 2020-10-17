using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Disease : MonoBehaviour
{
    public static float infectionRate = 0.01f;
    public static float spreadDistance = 6f;
    public static int incubationTime = 0; // Days
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void calculateSpread(List<NPC> npcs) {
        List<NPC> infected = npcs.FindAll(npc => npc.isInfected).ToList();
        int numInfected = infected.Count;
        System.Random rnd = new System.Random();
        foreach (NPC npc in npcs) {
            float r = rnd.Next(100) / 100f;
            float t = 1 - Mathf.Pow(1 - infectionRate, numInfected);
            if (r <= t) {
                npc.isInfected = true;
                NPCManager.numInfected++;
            }
        }
    }
}
