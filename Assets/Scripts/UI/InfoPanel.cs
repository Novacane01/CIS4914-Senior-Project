using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class InfoPanel : MonoBehaviour {
    Text nameText, taskText, healthText;
    RawImage img;
    // Start is called before the first frame update
    void Start() {
        nameText = transform.Find("Name_Text").GetComponent<Text>();
        taskText = transform.Find("Task_Text").GetComponent<Text>();
        healthText = transform.Find("Health_Text").GetComponent<Text>();
        img = GameObject.Find("RawImage").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void hide() {
        gameObject.SetActive(false);
    }

    public void updatePanel(NPC npc) {
        nameText.text = string.Format("Name: {0}", npc.name);
        taskText.text = string.Format("Next Task: {0}", npc.tasks.Peek().location.gameObject.transform.parent.name);
        healthText.text = string.Format("Health Status: {0}", npc.isInfected ? "Sick" : "Healthy");
        byte[] bytes = File.ReadAllBytes(string.Format("{0}/{1}.png", Application.streamingAssetsPath, npc.gameObject.name).Replace("(Clone)", ""));
        Texture2D texture = new Texture2D(100, 100);
        texture.LoadImage(bytes);
        img.texture = texture;
    }
}
