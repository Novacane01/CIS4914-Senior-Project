using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : MonoBehaviour {
    public List<Transform> houses;
    public List<Transform> buildings;
    public int numberOfTasks;
    public GameObject PopulationList;
    public uint population;
    public static uint numInfected;
    public GameObject npc;

    void Start() {
        System.Random rnd = new System.Random();
        int housesLength = houses.Capacity;
        int buildingsLength = buildings.Capacity;
        for (int i = 0; i < population; i++) {
            GameObject newNPCObject = UnityEngine.Object.Instantiate(npc, PopulationList.transform);
            NavMeshAgent navMeshAgent = newNPCObject.GetComponent<NavMeshAgent>();
            Transform house = houses[rnd.Next(housesLength)];
            Debug.Log(house.position);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(house.position, out hit, 20f, NavMesh.AllAreas)) {
                navMeshAgent.Warp(hit.position);
            }
            NPC newNPC = newNPCObject.AddComponent<NPC>();
            List<Task> currentTasks = new List<Task>();
            //for(int j = 0; j < numberOfTasks; j++) {
            //    currentTasks.Add(new Task(buildings[rnd.Next(buildingsLength)]));
            //}
            currentTasks.Add(new Task(buildings[0]));
            newNPC.loadTasks(currentTasks.ToArray());
            newNPC.house = house;
            if(numInfected > 0) {
                newNPC.isInfected = true;
                numInfected--;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}

/// int - population
/// function spawn() 
