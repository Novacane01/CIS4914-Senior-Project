using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {
    // Start is called before the first frame update
    List<NPC> npcList = new List<NPC>();
    NPCManager(short population) {
        for(short i = 0; i < population; i++) {
            npcList.Add(new NPC());
        }
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}

/// int - population
/// function spawn() 
