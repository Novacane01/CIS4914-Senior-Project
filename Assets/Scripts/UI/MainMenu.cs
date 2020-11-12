using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using JetBrains.Annotations;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

    public void playGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
