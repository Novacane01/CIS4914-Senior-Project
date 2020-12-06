using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour {
    public static Dictionary<string, Sprite> images = null;
    public Image currentImage;
    public List<Sprite> statuses;
    public int index = 0;
    private void Awake() {
        //Load a Sprite (Assets/Resources/Sprites/sprite01.png)
        if(images == null) {
            images = new Dictionary<string, Sprite>();
            Sprite [] sprites = Resources.LoadAll<Sprite>("UI_Icons");
            foreach (Sprite sprite in sprites) {
                Debug.Log(sprite.name.Replace("_icon",""));
                images.Add(sprite.name.Replace("_icon", ""), sprite);
            }
        }
    }
    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("cycleStatus", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update() {
        currentImage.enabled = statuses.Count > 0;
        transform.LookAt(CameraManager.activeCamera.transform);
    }

    public void addStatus(string type) {
       // statuses.Add(images[type]);
        //currentImage.sprite = statuses.Last();
    }

    public void removeStatus(string type) {
        //statuses.Remove(images[type]);
    }

    void cycleStatus() {
        if (statuses.Count > 1) {
            if (index == statuses.Count) {
                index = 0;
            }
            currentImage.sprite = statuses[index++];
        }
    }

}

// Icons made by https://www.flaticon.com/authors/freepik, https://www.flaticon.com/authors/dreamicons, https://www.flaticon.com/authors/aomam, https://www.flaticon.com/authors/vectors-market
