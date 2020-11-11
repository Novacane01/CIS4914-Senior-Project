using UnityEngine;

public class TaskBuilding : Building
{
    public override void OnNpcEnter(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        Transform npcLocation = npc.currentTaskLocation();

        if (npcLocation == transform)
        {
            occupancy.Add(npc);
            
            npc.agent.enabled = false;
            npc.diasble();
            npc.startTask();
            calculateSpread();
        }
    }

    public override void OnNpcLeave(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        Transform npcLocation = npc.currentTaskLocation();
        npc.enable();
    }
}
