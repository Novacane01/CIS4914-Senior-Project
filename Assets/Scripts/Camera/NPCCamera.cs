using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCamera : MonoBehaviour {
    private Camera npcCamera;

    private static int index = 0;
    public static NPC currentNPC;

    private void Awake() {
        npcCamera = GetComponent<Camera>();
        npcCamera.enabled = false;
    }

    public void changeNPC(string direction) {
        switch (direction) {
            case "Next":
                if (index < NPCManager.instance.npcList.Count - 1) {
                    currentNPC = NPCManager.instance.npcList[++index];
                }
                break;
            case "Previous":
                if (index > 0) {
                    currentNPC = NPCManager.instance.npcList[--index];
                }
                break;
            default:
                break;
        }
        CameraManager.infoPanel.updatePanel(currentNPC);
    }

    // Update is called once per frame
    void Update() {
        if(currentNPC) {
            transform.position = new Vector3(currentNPC.transform.position.x + 30f, transform.position.y, currentNPC.transform.position.z);
        }
    }

    public static NPC getCurrentNPC() {
        if(index >= 0 && index < NPCManager.instance.population) {
            return NPCManager.instance.npcList[index];
        }
        return null;
    }
}
