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

    public static Vector3 deathPosition = new Vector3(-91f, 0f,-71f);
    public static float deathHeight = 0f;

    // percent added to death rate due to condition
    public Dictionary<Condition, float> conditionEffects = new Dictionary<Condition, float> { 
        {Condition.Asthma, 0.2f } 
    };

    public static float infectionRate = Statistics.transRate;
    public static float spreadDistance = 6f;
    public static int incubationTime = 14; // Days
    public bool active = false;

    public static float getChanceOfDeath(NPC npc)  {
        return 0.2f;
    }
}
