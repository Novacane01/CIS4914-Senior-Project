using System.Collections.Generic;
using UnityEngine;

abstract public class Building : MonoBehaviour {
    protected List<NPC> occupancy = new List<NPC>();

    abstract public void OnNpcEnter(Collider other);
    abstract public void OnNpcLeave(Collider other);
}