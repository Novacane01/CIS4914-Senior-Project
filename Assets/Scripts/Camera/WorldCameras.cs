using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCameras : MonoBehaviour {
    public List<Camera> worldCameras;
    public static Camera currentCamera;
    public Dropdown cameraDropdown;
    // Start is called before the first frame update
    void Start() {
        currentCamera = worldCameras[0];
        cameraDropdown.onValueChanged.AddListener(delegate {
            changeWorldCamera(cameraDropdown.value);
        });
    }

    // Update is called once per frame
    void Update() {

    }

    public void changeWorldCamera(int cameraIndex) {
        currentCamera.enabled = false;
        currentCamera = worldCameras[cameraIndex];
        Enable();
    }

    public void Disable() {
        foreach(Camera cam in worldCameras) {
            cam.enabled = false;
        }
    }

    public void Enable() {
        currentCamera.enabled = true;
    }
}
