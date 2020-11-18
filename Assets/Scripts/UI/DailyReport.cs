using UnityEngine;
using UnityEngine.UI;

public class DailyReport : MonoBehaviour {
    public static DailyReport instance = null;

    public Canvas canvas;
    public Canvas canvas2;
    Text deathText, infectionText;
    private uint numDead = 0, numInfected = 0;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        canvas = GameObject.Find("DailyReport").GetComponent<Canvas>();
        canvas2 = GameObject.Find("EndDay").GetComponent<Canvas>();
        canvas.enabled = false;
        canvas2.enabled = false;
        deathText = transform.Find("Panel/DeathText").GetComponent<Text>();
        infectionText = transform.Find("Panel/InfectionText").GetComponent<Text>();
    }

    public void Hide() {
        canvas.enabled = false;
        canvas2.enabled = false;
    }

    public void Show() {
        uint newDead = NPCManager.instance.numDeaths - numDead;
        uint newInfected = NPCManager.instance.numInfected - numInfected;
        numDead = NPCManager.instance.numDeaths;
        numInfected = NPCManager.instance.numInfected;
        canvas.enabled = true;
        deathText.text = string.Format("New Deaths: {0}", newDead);
        infectionText.text = string.Format("New Infections: {0}", newInfected);
    }

    public void endShow() {
        numDead = NPCManager.instance.numDeaths;
        numInfected = NPCManager.instance.numInfected;
        canvas2.enabled = true;
        deathText.text = string.Format("Total Deaths: {0}", numDead);
        infectionText.text = string.Format("Total Infections: {0}", numInfected);
    }

}
