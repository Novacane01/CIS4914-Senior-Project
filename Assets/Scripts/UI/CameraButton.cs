using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraButton : MonoBehaviour {
    public CameraManager.CameraState cameraState;
    void Start() {
        CameraManager cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { cameraManager.switchCamera(cameraState); });
    }
}
