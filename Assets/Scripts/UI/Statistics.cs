using UnityEngine;


public class Statistics : MonoBehaviour {

    //initial from Config
    public static uint initPop { get; } = Config.initPop;
    public static uint initNumInfected { get; } = Config.initNumInfected;
    public static float transRate { get; } = Config.transRate;
    public static uint numDays { get; } = Config.numDays;
    public static uint tasksPerDay { get; } = Config.tasksPerDay;
    public static uint taskDuration { get; } = Config.taskDuration;
    // current and relevant information
    public static uint numInfected;
    public static uint currentDay;
    public static uint currPop;
    public static uint numDeaths;
    public static uint numImmune;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        numInfected = NPCManager.instance.numInfected;
        currentDay = TimeManager.currentDay;
        currPop = initPop - NPCManager.instance.numDeaths;
        numDeaths = NPCManager.instance.numDeaths;
        numImmune = NPCManager.instance.numImmune;
    }


}