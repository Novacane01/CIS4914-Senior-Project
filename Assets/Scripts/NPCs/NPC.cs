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
    public Queue<Task> tasks;
    public NavMeshAgent agent;
    public SkinnedMeshRenderer meshRenderer;

    //For creating line renderer object
    LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start() {
        Debug.Log("works not being atttatched to anything");
        agent = gameObject.GetComponent<NavMeshAgent>();
        meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update() {
        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        Task currentTask = tasks.Peek();
        if (currentTask.isDone) {
            tasks.Dequeue();
        }
        if (!currentTask.enRoute) {
            Debug.Log(tasks.Peek().location.transform.position);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(tasks.Peek().location.transform.position, out hit, 20f, NavMesh.AllAreas)) {
                Debug.Log(hit.position);
                agent.SetDestination(hit.position);
                currentTask.enRoute = true;
                lineRenderer.SetPosition(1, hit.position); //x,y and z position of the starting point of the line
            }
            // some time interval when they arrive
        }
        else if (currentTask.inProgress) {
            // Hide NPC until task is finished
            StartCoroutine(WaitForTaskCompletion(currentTask));
            currentTask.isDone = true;
        }
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

    public void loadTasks(Task[] tasks) {
        this.tasks = new Queue<Task>(tasks);
    }
}

/// float - % of death
/// Array[] - underlying conditions
/// bool - isInfected
/// Array[] - tasks

/// ******Unity Parameters*******
/// float - walkspeed
/// 