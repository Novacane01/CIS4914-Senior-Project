using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager {
    public static uint currentDay = 0;
    public Light directionalLight;
    public float lightIntensity;
    public float timeInDaySeconds;
    public TimeManager() {
        directionalLight = GameObject.Find("Directional light").GetComponent<Light>();
        lightIntensity = directionalLight.intensity;
        timeInDaySeconds = Config.taskDuration * Config.tasksPerDay;
    }

    public void endDay() {
        GameManager.uiManager.displayDayResults();
        Debug.Log("Day is over");
        incrementDay();
    }

    public void incrementDay() {
        directionalLight.intensity = lightIntensity;
        currentDay++;
    }
}
