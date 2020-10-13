using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class UpdateText : MonoBehaviour
{

    Text txtInfections;
    Text txtDeaths;
    Text txtPopulations;
    private int num;
    public 
    //public Statistics stats

    void Start()
    {
        num = 1;
        txtInfections = GameObject.Find("Canvas/Panel/TextDisplay/Infections").GetComponent<Text>();
        txtDeaths = GameObject.Find("Canvas/Panel/TextDisplay/Deaths").GetComponent<Text>();
        txtPopulations = GameObject.Find("Canvas/Panel/TextDisplay/Population").GetComponent<Text>();
    }

    //get indiviual components?? i think i will if i need to put them all in 1 place, unless i want them all as individual scripts

    // Update is called once per frame
    void Update()
    {
        num += 1;
        txtInfections.text = "Infections: " + num.ToString();
        txtDeaths.text = "Deaths: " + num.ToString();
        txtPopulations.text = "Population: " + num.ToString();
    }
}
