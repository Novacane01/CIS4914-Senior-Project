using UnityEngine;

public class TaskBuilding : Building
{
    public override void OnNpcEnter(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        if (npc.tasks.Count != 0 && npc.tasks.Peek().location.parent == transform)
        {
            npc.startTask();
            calculateSpread();
            occupancy.Add(npc);
            npc.meshRenderer.enabled = false;
        }
    }

    public override void OnNpcLeave(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        npc.meshRenderer.enabled = true;
    }
}
