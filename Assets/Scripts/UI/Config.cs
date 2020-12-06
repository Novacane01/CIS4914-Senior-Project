using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Config : MonoBehaviour
{
    //public InputField popInput;
    //public InputField infectedInput;
    //public InputField transmissionInput;
    public Slider popInput;
    public Slider infectedInput;
    public Slider transInput;
    public Slider numDaysInput;
    public Slider taskNumInput;
    public Slider taskDurInput;
    public Slider deathRateInput;
    public Slider daysTilImmuneInput;
    public Text popText;
    public Text infectedText;
    public Text transText;
    public Text numDaysText;
    public Text taskNumText;
    public Text taskDurText;
    public Text deathRateText;
    public Text daysTilImmuneText;
    public GameObject popUpWindow;

    public static uint initPop = 50;
    public static uint initNumInfected = 1;
    public static float transRate = 0.1f;
    public static uint numDays = 3;
    public static uint tasksPerDay = 6;
    public static uint taskDuration = 5;
    public static uint daysTilImmune = 4;
    public static float deathRate = 0.1f;

    private void Start()
    {
        popInput.value = initPop;
        infectedInput.value = initNumInfected;
        transInput.value = transRate;
        numDaysInput.value = numDays;
        taskNumInput.value = tasksPerDay;
        taskDurInput.value = taskDuration;
        deathRateInput.value = deathRate;
        daysTilImmuneInput.value = daysTilImmune;
    }

    private void Update()
    {
        popText.text = popInput.value.ToString();
        infectedText.text = infectedInput.value.ToString();
        transText.text = transInput.value.ToString();
        numDaysText.text = numDaysInput.value.ToString();
        taskNumText.text = taskNumInput.value.ToString();
        taskDurText.text = taskDurInput.value.ToString();
        deathRateText.text = deathRateInput.value.ToString();
        daysTilImmuneText.text = daysTilImmuneInput.value.ToString();
    }

    private void ValueChange()
    {
        //put numeric constraint
        try
        {
            initPop = Convert.ToUInt32(popText.text);
            initNumInfected = Convert.ToUInt32(infectedText.text);
            initPop = Convert.ToUInt32(popInput.value);
            initNumInfected = Convert.ToUInt32(infectedInput.value);
            transRate = Convert.ToSingle(transInput.value);
            tasksPerDay = Convert.ToUInt32(taskNumText.text);
            taskDuration = Convert.ToUInt32(taskDurText.text);
            numDays = Convert.ToUInt32(numDaysText.text);
            deathRate = Convert.ToSingle(deathRateInput.value);
            daysTilImmune = Convert.ToUInt32(daysTilImmuneInput.value);

        }
        catch (FormatException e)
        {
            Debug.Log("Given input is not a numeric value: " + e.ToString());
        }

    }

    public void OpenGame()
    {
        ValueChange();
        Debug.Log("Initial Population: " + initPop);
        Debug.Log("Initial Num Infected: " + initNumInfected);
        Debug.Log("Transmission Rate: " + transRate);
        Debug.Log("Number of days: " + numDays);
        Debug.Log("Tasks per day for each npc: " + tasksPerDay);
        Debug.Log("Task duration: " + taskDuration);
        if (initPop == 0 || initNumInfected == 0 || transRate == 0 || numDays == 0)
        {
            popUpWindow.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

}
