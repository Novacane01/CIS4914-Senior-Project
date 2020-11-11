using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NPC : MonoBehaviour {

    // Components of NPC entity
    public NavMeshAgent agent;
    public SkinnedMeshRenderer meshRenderer;

    // Called upon completing day, callback function defined in NPC manager
    public UnityEvent completedDay = new UnityEvent();

    public Transform house;

    public new string name;
    public bool isInfected = false;

    // Underlying conditions that may increase the risk of death
    public Disease.Condition[] underlyingConditions;
    
    public bool isDead { get; private set;  } = false;
    public bool isImmune { get; private set; } = false;

    private Queue<Task> tasks;
    private int daysWithDisease = 0;
    private float deathChance = 0.0f;
    private bool headingHome = false;
    public bool inDoor = true;
    

    // Start is called before the first frame update
    void Start() {
        meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        deathChance = Disease.getChanceOfDeath(this);
    }

    void Update() {

        if (!isDead)
        {
            if (tasks.Count != 0)
            {
                Task currentTask = tasks.Peek();
                if (currentTask.isDone)
                {
                    Debug.Log("Task complete: " + name);
                    tasks.Dequeue();
                }

                // Haven't started moving towards location yet
                else if (!currentTask.enRoute && agent.enabled)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(tasks.Peek().location.transform.position, out hit, 20f, NavMesh.AllAreas))
                    {
                        agent.SetDestination(hit.position);
                        currentTask.enRoute = true;
                    }
                }
            }

            // Return home when finished all tasks
            if (tasks.Count == 0 && !headingHome)
            {
                if (!agent.enabled) { agent.enabled = true; }
                Debug.Log("heading home: " + name);
                agent.SetDestination(house.Find("Door").transform.position);
                StartCoroutine(waitUntilHome());
            }
        }
    }

    // Initiate task on top of the queue
    public void startTask() {
        Debug.Log("Starting task: " + name);
        Task currentTask = tasks.Peek();
        currentTask.enRoute = false;
        StartCoroutine(waitForTaskCompletion(currentTask));
    }

    IEnumerator waitForTaskCompletion(Task task) {
        // Start another coroutine to calculate spread of disease every X seconds
        yield return new WaitForSeconds(task.duration); // Wait for the task duration then continue
        agent.enabled = true;
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

    IEnumerator waitUntilHome() {
        headingHome = true;
        yield return new WaitUntil(() => !agent.enabled);
        isDead = checkForDeath();
        completedDay.Invoke();
    }


    public void initializeDay(Task[] tasks) {
        this.tasks = new Queue<Task>(tasks);
        headingHome = false;
        agent.enabled = true;
    }

    public Transform currentTaskLocation() {
        if (tasks.Count != 0) {
            return tasks.Peek().location.parent;
        }
        return null;
    }

    public int numTasks() {
        return tasks.Count;
    }

    private bool checkForDeath() {
        if (isInfected && !isDead) { // chekcs here in case we go from infected -> not infected (survive the disease)
        
            System.Random rnd = new System.Random();
            float r = rnd.Next(100) / 100f;

            if (r < deathChance) {
                return true;
            }

            daysWithDisease++;
            if(daysWithDisease == Disease.incubationTime) {
                isInfected = false;
                isImmune = true;
            }

        }

        return false;
    }

    public void diasble() {
        meshRenderer.enabled = false;
        var animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;
        //agent.enabled = !agent.enabled;
    }

    public void enable()
    {
        meshRenderer.enabled = true;
        var animator = gameObject.GetComponent<Animator>();
        animator.enabled = true;
    }
}

