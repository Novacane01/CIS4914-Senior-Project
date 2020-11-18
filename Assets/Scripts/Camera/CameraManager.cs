using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {
    public enum CameraState {
        NPC, FREE, WORLD
    };
    public Camera npcCamera;
    //public WorldCameras worldCameras;
    public List<Camera> worldCameras;
    private int worldCameraIndex = 0;
    public Camera freeCamera;
    public CameraState cameraState;
    public static InfoPanel infoPanel;
    public static Camera activeCamera;
    public Dropdown cameraDropdown;


    void Start() {
        activeCamera = worldCameras[worldCameraIndex];
        infoPanel = GameObject.Find("NPC_Info_Panel").GetComponent<InfoPanel>();
        infoPanel.gameObject.SetActive(false);
        cameraDropdown.onValueChanged.AddListener(delegate {
            worldCameraIndex = cameraDropdown.value;
        });
    }

    public void switchCamera(CameraState cameraState) {
        activeCamera.enabled = false;
        switch(cameraState) {
            case CameraState.NPC:
                activeCamera = npcCamera;
                infoPanel.gameObject.SetActive(true);
                infoPanel.updatePanel(NPCCamera.currentNPC.GetComponent<NPC>());
                break;
            case CameraState.WORLD:
                activeCamera = worldCameras[worldCameraIndex];
                infoPanel.gameObject.SetActive(false);
                break;
            case CameraState.FREE:
                activeCamera = freeCamera;
                infoPanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        activeCamera.enabled = true;
    }
}
