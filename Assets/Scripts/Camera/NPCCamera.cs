using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCamera : MonoBehaviour {
    private Camera npcCamera;
    public static NPC currentNPC;

    private void Awake() {
        npcCamera = GetComponent<Camera>();
        npcCamera.enabled = false;
    }

    public void changeNPC(string direction) {
        switch (direction) {
            case "Next":
                if (currentNPC.index < NPCManager.instance.npcList.Count - 1) {
                    currentNPC = NPCManager.instance.npcList[currentNPC.index + 1];
                }
                break;
            case "Previous":
                if (currentNPC.index > 0) {
                    currentNPC = NPCManager.instance.npcList[currentNPC.index - 1];
                }
                break;
            default:
                break;
        }
        CameraManager.infoPanel.updatePanel(currentNPC);
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(currentNPC.transform.position.x + 30f, transform.position.y, currentNPC.transform.position.z);
    }
}
