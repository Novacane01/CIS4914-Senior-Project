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
    };

    public static float infectionRate = Statistics.transRate;
    public static int incubationTime = (int)Config.daysTilImmune; // Days

    public static float getChanceOfDeath(NPC npc)  {
        return Config.deathRate;
    }
}
