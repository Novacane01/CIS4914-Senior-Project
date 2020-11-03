using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager {
    public static uint currentDay = 0;
    public Light directionalLight;
    public float lightIntensity;
    public float timeInDaySeconds;
    DailyReport dailyReport;

    public TimeManager() {
        dailyReport = GameObject.Find("DailyReport").GetComponent<DailyReport>();
        directionalLight = GameObject.Find("Directional light").GetComponent<Light>();
        lightIntensity = directionalLight.intensity;
        timeInDaySeconds = Config.taskDuration * Config.tasksPerDay;
    }

    public void endDay() {
        if(Settings.dailyReportToggle.isOn) {
            if(currentDay >= Config.numDays) {

            }
            else {
                dailyReport.Show();
            }
        }
        else {
            incrementDay();
        }
        Debug.Log("Day is over");
    }

    public void incrementDay() {
        directionalLight.intensity = lightIntensity;
        currentDay++;
        NPCManager.instance.reAssignTasks();
    }
}
