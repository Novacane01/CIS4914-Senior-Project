using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public enum CameraState {
        NPC, FREE, WORLD
    };
    public Camera npcCamera;
    public Camera worldCamera;
    public Camera freeCamera;
    public CameraState cameraState;
    public static InfoPanel infoPanel;

    void Start() {
        infoPanel = GameObject.Find("NPC_Info_Panel").GetComponent<InfoPanel>();
        infoPanel.gameObject.SetActive(false);
    }

    public void switchCamera(CameraState cameraState) {
        switch(cameraState) {
            case CameraState.NPC:
                //npcCamera.transform.parent = currentNPC;
                infoPanel.gameObject.SetActive(true);
                infoPanel.updatePanel(NPCCamera.currentNPC.GetComponent<NPC>());
                npcCamera.enabled = true;
                worldCamera.enabled = false;
                freeCamera.enabled = false;
                break;
            case CameraState.WORLD:
                infoPanel.gameObject.SetActive(false);
                npcCamera.enabled = false;
                worldCamera.enabled = true;
                freeCamera.enabled = false;
                break;
            case CameraState.FREE:
                infoPanel.gameObject.SetActive(false);
                npcCamera.enabled = false;
                worldCamera.enabled = false;
                freeCamera.enabled = true;
                break;
            default:
                break;
        }
    }
}
