using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Disease
{

    public enum Condition
    {
        Asthma,
        Fever,
        Cough,
    }

    // percent added to death rate due to condition
    public Dictionary<Condition, float> conditionEffects = new Dictionary<Condition, float> { 
        {Condition.Asthma, 0.2f } 
    } ;

    public static float infectionRate = 0.50f;
    public static float spreadDistance = 6f;
    public static int incubationTime = 0; // Days
    public bool active = false;

    public static bool hasDied(NPC npc)  {
        if(npc.isInfected)
        {

        }
        
        return false;
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

        Debug.Log("Number Infected: " + NPCManager.numInfected);
    }
}
