using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState { PLAYING, PAUSED};
    public static GameState gameState;
    public static NPCManager npcManager;
    public static TimeManager timeManager;
    public static UIManager uiManager;
    // Start is called before the first frame update
    void Start() {
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        timeManager = new TimeManager(); /*GameObject.Find("TimeManager").GetComponent<TimeManager>();*/
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        npcManager.dayFinished.AddListener(() => timeManager.endDay());

        gameState = GameState.PLAYING;
    }

    // Update is called once per frame
    void Update() {
        //if (npcManager.tasksCompleted == npcManager.totalNumTasks) {
        //    //timeManager.endDay
        //    uiManager.displayDayResults();
        //    timeManager.incrementDay();
        //}
        timeManager.directionalLight.intensity -= (timeManager.lightIntensity/timeManager.timeInDaySeconds) * Time.deltaTime;
    }
}
