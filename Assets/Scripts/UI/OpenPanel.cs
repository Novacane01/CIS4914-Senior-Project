using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour{
    // Start is called before the first frame update

    public GameObject Panel;
    public bool openPanel = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openPanel == false)
            {
                Panel.gameObject.SetActive(true);
                openPanel = true;
                //UnityEngine.Debug.log("Open Menu");
            }
            else
            {
                Panel.SetActive(false);
                openPanel = false;
                //UnityEngine.Debug.log("Close Menu");
            }
        }
    }
}
