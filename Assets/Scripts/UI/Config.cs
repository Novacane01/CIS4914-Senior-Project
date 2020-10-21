using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Config : MonoBehaviour {
    // Start is called before the first frame update
    public InputField popInput;
    public InputField infectedInput;
    public InputField infectRateInput;
    public InputField numDaysInput;
    public InputField taskNumInput;
    public InputField taskDurInput;

    public static int initPop = 0;
    public static int initInfectPop = 0;
    public static int initRate = 0;
    public static int numDays = 3;
    public static int tasksPerDay = 6;
    public static int taskDuration = 5;


    private void ValueChange() {
        //put numeric constraint
        try {
            initPop = Convert.ToInt32(popInput.text.ToString());
            initInfectPop = Convert.ToInt32(infectedInput.text.ToString());
            initRate = Convert.ToInt32(infectRateInput.text.ToString());
            tasksPerDay = Convert.ToInt32(numDaysInput.text.ToString());
            taskDuration = Convert.ToInt32(taskNumInput.text.ToString());
            numDays = Convert.ToInt32(taskDurInput.text.ToString());
        }
        catch (FormatException) {
            Debug.Log("given input is not a numeric value");
        }


    }


    public void OpenGame() {
        Debug.Log("PLEASE");
        ValueChange();
        Debug.Log(initPop);
        Debug.Log(initInfectPop);
        Debug.Log(initRate);
        Debug.Log(numDays);
        Debug.Log(tasksPerDay);
        Debug.Log(taskDuration);
        if (initPop == 0 || initInfectPop == 0 || initRate == 0) {
            Debug.Log("Popup window with stop message");
        }
        else {
            SceneManager.LoadScene(1);
        }

    }

}
