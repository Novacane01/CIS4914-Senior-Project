using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : MonoBehaviour {
    public List<Transform> houses;
    public List<Transform> buildings = new List<Transform>(GameObject.Find("TaskBuildings").GetComponentsInChildren<Transform>());
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
            Transform door = house.Find("Door").transform;
            Debug.Log("Door Transform Position: ");
            Debug.Log(door.position);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(door.position, out hit, 20f, NavMesh.AllAreas)) {
                // Debug.Log(hit.position);
                // Debug.Log(hit.distance);
                Debug.Log(hit);
                navMeshAgent.Warp(hit.position);
                Debug.Log(newNPCObject.transform.position);
            } else {
                Debug.Log("ERROR FINDING SAMPLE POSITION");
            }
            NPC newNPC = newNPCObject.AddComponent<NPC>();
            List<Task> currentTasks = new List<Task>();
            for(int j = 0; j < numberOfTasks; j++) {
                currentTasks.Add(new Task(buildings[rnd.Next(buildingsLength)].Find("Door").transform));
            }
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
