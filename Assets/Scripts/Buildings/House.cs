using UnityEngine;

public class House : Building
{
    public override void OnNpcEnter(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();

        if (npc.house == transform && npc.agent && npc.numTasks() == 0)
        {
            npc.agent.enabled = false;
            npc.diasble();

            calculateSpread();
            occupancy.Add(npc);
        }
    }
    public override void OnNpcLeave(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();

        if (npc.house == transform)
        {
            npc.enable();
        }   
    }
}
