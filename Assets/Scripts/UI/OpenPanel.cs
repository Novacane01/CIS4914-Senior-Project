using UnityEngine;

public class OpenPanel : MonoBehaviour{

    public GameObject Panel;
    public bool openPanel = false;

    void Start() {
        Panel.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (openPanel == false) {
                Panel.gameObject.SetActive(true);
                openPanel = true;
            }
            else {
                Panel.SetActive(false);
                openPanel = false;
            }
        }
    }
}
