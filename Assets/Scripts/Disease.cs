using System.Collections;
using System.Collections.Generic;
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

    public static float getChanceOfDeath(NPC npc)  {
     
        return 0f;
    }
}
