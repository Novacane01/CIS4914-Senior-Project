using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager {
    public static uint currentDay = 0;
    public Light directionalLight;
    public float lightIntensity;
    public float timeInDaySeconds;
    DailyReport dailyReport;
    EndDayReport endDayReport;
    public TimeManager() {
        dailyReport = GameObject.Find("DailyReport").GetComponent<DailyReport>();
        endDayReport = GameObject.Find("EndDayReport").GetComponent<EndDayReport>();
        directionalLight = GameObject.Find("Directional light").GetComponent<Light>();
        lightIntensity = directionalLight.intensity;
        timeInDaySeconds = Config.taskDuration * Config.tasksPerDay;

    }

    public void endDay() {
        currentDay++;
        if (Settings.dailyReportToggle.isOn) {
            if(currentDay >= Config.numDays) {
                Debug.Log("No more days");
                endDayReport.Show();
            }
            else {
                dailyReport.Show();
            }
        }
        else {
            incrementDay();
        }

        if(currentDay < Config.numDays) {
            Debug.Log("Next Day: " + currentDay);
        }
    }

    public void incrementDay() {
        NPCManager.instance.reAssignTasks();
    }
}
