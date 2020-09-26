using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour
{
    public static float infectionRate;
    public static float spreadDistance;
    public static int incubationTime; // Days
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
        System.Random rnd = new System.Random();
        foreach (NPC npc in npcs) {
            if (rnd.Next(100)/100f <= infectionRate) {
                npc.isInfected = true;
            }
        }
    }
}
