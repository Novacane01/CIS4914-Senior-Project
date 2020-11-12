using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NPC : MonoBehaviour {
    // Underlying conditions that may increase the risk of death


    public UnityEvent completedDay = new UnityEvent();

    public Transform house;
    public HUD hud;
    public new string name;
    public int index;
    public bool isInfected = false;
    public Disease.Condition[] underlyingConditions;
    public Queue<Task> tasks;
    public NavMeshAgent agent;
    public SkinnedMeshRenderer meshRenderer;
    public bool isDead = false;
    public bool isImmune = false;

    private int daysWithDisease = 0;
    public static uint numDeaths = 0;

    private float deathChance = 0.0f;


    //For creating line renderer object
    //LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();
        meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        deathChance = Disease.getChanceOfDeath(this);

        hud = GetComponentInChildren<HUD>();
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


        if (!isDead) {
            if (tasks.Count != 0) {
                Task currentTask = tasks.Peek();
                if (currentTask.isDone) {
                    tasks.Dequeue();
                    // Return home when finished all tasks
                    if (tasks.Count == 0) {
                        agent.SetDestination(house.Find("Door").transform.position);
                        hud.addStatus("home");
                        StartCoroutine(waitUntilHome());
                    }
                }

                // Haven't started moving towards location yet
                else if (!currentTask.enRoute) {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(tasks.Peek().location.transform.position, out hit, 20f, NavMesh.AllAreas)) {
                        agent.SetDestination(hit.position);
                        currentTask.enRoute = true;
                        hud.addStatus("task");
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
        else if (agent && agent.destination.x == Disease.deathPosition.x && agent.destination.z == Disease.deathPosition.z && agent.remainingDistance < 0.01f) {
            Debug.Log("Made it to death");
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Animator>());

            agent = null;

            transform.rotation = Quaternion.LookRotation(new Vector3(90f, 0f, 0f));
            transform.Rotate(new Vector3(-90f, 0f, 90f));
            transform.Translate(0f, 0f, Disease.deathHeight);
            Disease.deathHeight += 0.1f;
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
        Debug.Log(string.Format("{0} finished task: {1}",name,task.location));
        task.isDone = true;
        hud.removeStatus("task");
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
        yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f));
        isDead = checkForDeath();
        hud.statuses.Clear();
        completedDay.Invoke();
    }

    // Convert Array of tasks to Queue
    public void loadTasks(Task[] tasks) {
        this.tasks = new Queue<Task>(tasks);
    }


    private bool checkForDeath() {
        if (isInfected && !isDead) { // chekcs here in case we go from infected -> not infected (survive the disease)

            System.Random rnd = new System.Random();
            float r = rnd.Next(100) / 100f;

            if (r < deathChance) {
                return true;
            }

            daysWithDisease++;
            if (daysWithDisease == Disease.incubationTime) {
                isInfected = false;
                isImmune = true;
            }

        }
        else if (isDead) {
            numDeaths++;
            return true;
        }
        return false;
    }
}
