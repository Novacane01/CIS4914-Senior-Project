using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    public static Toggle dailyReportToggle;
    private GameObject settingsPanel; 
    // Start is called before the first frame update
    void Start() {
        settingsPanel = transform.Find("SettingsPanel").gameObject;
        dailyReportToggle = settingsPanel.transform.Find("Daily_Report_Toggle").GetComponent<Toggle>();
    }

    public void ShowHide() {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // Update is called once per frame
    void Update() {

    }
}
