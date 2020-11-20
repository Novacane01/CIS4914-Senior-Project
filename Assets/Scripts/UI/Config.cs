using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

<<<<<<< HEAD
public class Config : MonoBehaviour
{
    // Start is called before the first frame update
    //public InputField popInput;
    //public InputField infectedInput;
    //public InputField transmissionInput;
    public Slider popInput;
    public Slider infectedInput;
    public Slider transInput;
    public Slider numDaysInput;
    public Slider taskNumInput;
    public Slider taskDurInput;
    public Text popText;
    public Text infectedText;
    public Text transText;
    public Text numDaysText;
    public Text taskNumText;
    public Text taskDurText;
    public GameObject popUpWindow;
=======
public class Config : MonoBehaviour {
    // Start is called before the first frame update
    public InputField popInput;
    public InputField infectedInput;
    public InputField transmissionInput;
    public InputField numDaysInput;
    public InputField taskNumInput;
    public InputField taskDurInput;
>>>>>>> 60c6a530c02cead4a8c3b8d194295934bd094b39

    public static uint initPop = 0;
    public static uint initNumInfected = 0;
    public static float transRate = 0f;
    public static uint numDays = 3;
    public static uint tasksPerDay = 6;
    public static uint taskDuration = 5;

<<<<<<< HEAD

    private void Update()
    {
        popText.text = popInput.value.ToString();
        infectedText.text = infectedInput.value.ToString();
        transText.text = transInput.value.ToString();
        numDaysText.text = numDaysInput.value.ToString();
        taskNumText.text = taskNumInput.value.ToString();
        taskDurText.text = taskDurInput.value.ToString();

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
        }
        catch (FormatException e)
        {
=======
    private void ValueChange() {
        //put numeric constraint
        try {
            initPop = Convert.ToUInt32(popInput.text.ToString());
            initNumInfected = Convert.ToUInt32(infectedInput.text.ToString());
            transRate = Convert.ToSingle(transmissionInput.text.ToString());
            tasksPerDay = Convert.ToUInt32(taskNumInput.text.ToString());
            taskDuration = Convert.ToUInt32(taskDurInput.text.ToString());
            numDays = Convert.ToUInt32(numDaysInput.text.ToString());
        }
        catch (FormatException e) {
>>>>>>> 60c6a530c02cead4a8c3b8d194295934bd094b39
            Debug.Log("Given input is not a numeric value: " + e.ToString());
        }

    }

<<<<<<< HEAD
    public void OpenGame()
    {
        Debug.Log("wer here");
=======

    public void OpenGame() {
>>>>>>> 60c6a530c02cead4a8c3b8d194295934bd094b39
        ValueChange();
        Debug.Log("Initial Population: " + initPop);
        Debug.Log("Initial Num Infected: " + initNumInfected);
        Debug.Log("Transmission Rate: " + transRate);
        Debug.Log("Number of days: " + numDays);
        Debug.Log("Tasks per day for each npc: " + tasksPerDay);
        Debug.Log("Task duration: " + taskDuration);
<<<<<<< HEAD
        if (initPop == 0 || initNumInfected == 0 || transRate == 0 || numDays == 0)
        {
            Debug.Log("SOmethig went wronf");
            popUpWindow.SetActive(true);
        }
        else
        {
=======
        if (initPop == 0 || initNumInfected == 0 || transRate == 0) {
            Debug.Log("Popup window with stop message");
        }
        else {
>>>>>>> 60c6a530c02cead4a8c3b8d194295934bd094b39
            SceneManager.LoadScene(1);
        }
    }

}
