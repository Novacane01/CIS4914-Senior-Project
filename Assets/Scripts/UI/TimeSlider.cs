using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TimeSlider : MonoBehaviour {
    public Slider slider;
    private float fixedDeltaTime;
    Text timeSliderText;
    // Start is called before the first frame update
    void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { setTimeScale(); });
        timeSliderText = GetComponentInChildren<Text>();
    }

    public void setTimeScale() {
        Time.timeScale = slider.value;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        timeSliderText.text = string.Format("x{0}", slider.value);
    }
}
