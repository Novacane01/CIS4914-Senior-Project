using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    public enum Conditions {
        Asthma,
        Fever,
        Cough,
    }

    public float deathChance = 0f;
    public bool isInfected = false;
    public Conditions[] underlyingConditions;
    private Queue<Task> tasks;
    [SerializeField]
    public Task[] initialTasks;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start() {
        tasks = new Queue<Task>(initialTasks);
    }

    // Update is called once per frame
    void Update() {
        Task currentTask = tasks.Peek();
        if (currentTask.isDone) {
            tasks.Dequeue();
        }
        if (!currentTask.inProgress) {
            Debug.Log(tasks.Peek().location.transform.position);
            agent.SetDestination(tasks.Peek().location.transform.position);
            currentTask.inProgress = true;
            // some time interval when they arrive
        }
    }
}

/// float - % of death
/// Array[] - underlying conditions
/// bool - isInfected
/// Array[] - tasks

/// ******Unity Parameters*******
/// float - walkspeed
/// 