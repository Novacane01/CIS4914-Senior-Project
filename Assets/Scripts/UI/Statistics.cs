using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class Statistics : MonoBehaviour{

    //initial from Config
    public static uint initPop = Config.initPop;
    public static uint initNumInfected = Config.initNumInfected;
    public static float transRate = Config.transRate;
    public static uint numDays = Config.numDays;
    public static uint tasksPerDay = Config.tasksPerDay;
    public static uint taskDuration = Config.taskDuration;
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
        currPop = initPop - NPC.numDeaths;
        numDeaths = NPC.numDeaths;
        numImmune = NPC.numImmune;
        
    }


}