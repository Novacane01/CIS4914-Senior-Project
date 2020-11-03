using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    // Start is called before the first frame update
    Text DeathsDay;
    Text InfectedDay;
    Text DaysLeft;

   
    void Start() {
        DeathsDay = GameObject.Find("UI/DaySummary/Panel/TextDisplay/DeathsDay").GetComponent<Text>();
        InfectedDay = GameObject.Find("UI/StatsUI/Panel/TextDisplay/InfectedDay").GetComponent<Text>();
        DaysLeft = GameObject.Find("UI/StatsUI/Panel/TextDisplay/DaysLeft").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void displayDayResults() {

    }

}
