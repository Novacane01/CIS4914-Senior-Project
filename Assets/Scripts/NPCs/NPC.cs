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

    public new string name;
    public int index;
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
        agent = gameObject.GetComponent<NavMeshAgent>();
        meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        //lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        //lineRenderer.startColor = Color.black;
        //lineRenderer.endColor = Color.black;
        //lineRenderer.startWidth = 1f;
        //lineRenderer.endWidth = 1f;
        //lineRenderer.positionCount = 2;
        //lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update() {
        //For drawing line in the world space, provide the x,y,z values
        //lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        if(tasks.Count != 0) {
            Task currentTask = tasks.Peek();
            if (currentTask.isDone) {
                tasks.Dequeue();
                // Return home when finished all tasks
                if(tasks.Count == 0){
                    agent.SetDestination(house.Find("Door").transform.position);
                }
            }
            // Haven't started moving towards location yet
            if (!currentTask.enRoute) {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(tasks.Peek().location.transform.position, out hit, 20f, NavMesh.AllAreas)) {
                    agent.SetDestination(hit.position);
                    currentTask.enRoute = true;
                    //lineRenderer.SetPosition(1, hit.position); //x,y and z position of the starting point of the line
                }
            }
            // Reached destination; initate task
            else if (currentTask.inProgress) {
                // Hide NPC until task is finished
                StartCoroutine(waitForTaskCompletion(currentTask));
            }
        }
    }

    // Initiate task on top of the queue
    public void startTask() {
        Task currentTask = tasks.Peek();
        StartCoroutine(waitForTaskCompletion(currentTask));
    }

    IEnumerator waitForTaskCompletion(Task task) {
        // Start another coroutine to calculate spread of disease every X seconds
        yield return new WaitForSeconds(task.duration); // Wait for the task duration then continue
        task.isDone = true;
    }

    // Periodically calculate disease spread 
    IEnumerator checkForDiseaseSpread(Task task) {
        if (!task.isDone) {
            task.location.parent.GetComponent<TaskBuilding>().calculateSpread();
            yield return new WaitForSeconds(2f);
            checkForDiseaseSpread(task);
        }
        yield return 0;
    }

    // Convert Array of tasks to Queue
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