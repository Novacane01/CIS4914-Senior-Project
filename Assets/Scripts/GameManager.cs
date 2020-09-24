using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    enum GameState {
        MainMenu,
        Playing,

    }
    public short population;
    public UIManager UIManager;
    public NPCManager NPCManager;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}

// Game manager will run NPCManager, UIManager, etc...
