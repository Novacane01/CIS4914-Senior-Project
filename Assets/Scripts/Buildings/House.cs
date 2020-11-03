using UnityEngine;

public class House : Building
{
    public override void OnNpcEnter(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        if (npc.house == transform)
        {
            calculateSpread();
            occupancy.Add(npc);
            if(npc.meshRenderer != null)
            {
                npc.meshRenderer.enabled = false;
            }
        }
    }
    public override void OnNpcLeave(Collider other)
    {
        NPC npc = other.gameObject.GetComponent<NPC>();
        npc.meshRenderer.enabled = true;
    }
}
