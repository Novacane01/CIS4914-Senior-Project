using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState { PLAYING, PAUSED};
    public static GameState gameState;
    public static TimeManager timeManager;
    // Start is called before the first frame update
    void Start() {
        timeManager = new TimeManager(); /*GameObject.Find("TimeManager").GetComponent<TimeManager>();*/

        NPCManager.instance.dayFinished.AddListener(() => {
            timeManager.endDay();
        });

        gameState = GameState.PLAYING;
    }
}
