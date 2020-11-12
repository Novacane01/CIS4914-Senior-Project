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
    private uint num;
    //public Statistics stats

    void Start()
    {
        txtInfections = GameObject.Find("UI/StatsUI/Panel/TextDisplay/Infections").GetComponent<Text>();
        txtDeaths = GameObject.Find("UI/StatsUI/Panel/TextDisplay/Deaths").GetComponent<Text>();
        txtPopulations = GameObject.Find("UI/StatsUI/Panel/TextDisplay/Population").GetComponent<Text>();
    }

    //get indiviual components?? i think i will if i need to put them all in 1 place, unless i want them all as individual scripts

    // Update is called once per frame
    void Update()
    {
        num += 1;
        //txtInfections.text = Statistics.numInfected.ToString();
        txtInfections.text = Statistics.numInfected.ToString();
        txtDeaths.text = Statistics.numDeaths.ToString();
        txtPopulations.text = Statistics.currPop.ToString();
    }
}
