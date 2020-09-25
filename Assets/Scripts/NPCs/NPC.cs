using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    // Underlying conditions that may increase the risk of death
    public enum Conditions {
        Asthma,
        Fever,
        Cough,
    }

    public Transform house;

    public float deathChance = 0f;
    public bool isInfected = false;
    public Conditions[] underlyingConditions;
    private Queue<Task> tasks;
    [SerializeField]
    public Task[] initialTasks; // Initial tasks of NPC (assinged in inspector)
    public NavMeshAgent agent;
    public SkinnedMeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("works not being atttatched to anything");
        tasks = new Queue<Task>(initialTasks);
        meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        //Task currentTask = tasks.Peek();
        //if (currentTask.isDone) {
        //    tasks.Dequeue();
        //}
        //if (!currentTask.inProgress) {
        //    Debug.Log(tasks.Peek().location.transform.position);
        //    NavMeshHit hit;
        //    if(NavMesh.SamplePosition(tasks.Peek().location.transform.position, out hit, 20f, NavMesh.AllAreas)) {
        //        Debug.Log(hit.position);
        //        agent.SetDestination(hit.position);
        //    }
            
        //    currentTask.inProgress = true;
        //    // some time interval when they arrive
        //}
        //else {
        //    // Hide NPC until task is finished
        //    gameObject.SetActive(false);
        //    StartCoroutine(WaitForTaskCompletion(currentTask));
        //    gameObject.SetActive(false);
        //    currentTask.isDone = true;
        //}
    }

    public void startTask() {
        // Hide NPC until task is finished
        Debug.Log("Starting task");
        Task currentTask = tasks.Peek();
        Debug.Log(currentTask.duration);
        StartCoroutine(WaitForTaskCompletion(currentTask));
    }

    IEnumerator WaitForTaskCompletion(Task task) {
        yield return new WaitForSeconds(task.duration);
        task.isDone = true;
        Debug.Log("Finished task");
    }
}

/// float - % of death
/// Array[] - underlying conditions
/// bool - isInfected
/// Array[] - tasks

/// ******Unity Parameters*******
/// float - walkspeed
/// 