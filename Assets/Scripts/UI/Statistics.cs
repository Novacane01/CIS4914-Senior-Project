using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class Statistics : MonoBehaviour{

    //# who are immunce
    public NPCManager nPCManager;
    public uint populationStat;
    private uint numInfectedStat;
    private uint numDeathsStat; 

    // Start is called before the first frame update
    void Start(){
        populationStat = 0;
        numInfectedStat = 0;
        numDeathsStat = 0;
}

    // Update is called once per frame
    void Update(){
        //populationStat = nPCManager.population;
        //numInfectedStat = nPCManager.numInfected;
        //private uintnumDeaths = 0; 
        populationStat +=1;
        numInfectedStat += 1;
        numDeathsStat += 1;
    }
    //adds on for later
    //social distanced
    //masks
    //vacinne??

}