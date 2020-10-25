using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Graph : MonoBehaviour{
    // Start is called before the first frame update
    private RectTransform graphDisplay;
    Text YaxisTop;
    Text YaxisMid;
    Text YaxisBot;
    //
    //Text txtDeaths;
    //Text txtPopulations;
    void Start(){
        graphDisplay = transform.Find("GraphDisplay").GetComponent<RectTransform>();
        YaxisTop = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisTop").GetComponent<Text>();
        YaxisMid = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisMid").GetComponent<Text>();
        YaxisBot = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisBot").GetComponent<Text>();
        //create list of values to test 
        List<int> values = new List<int>() { 20, 60, 80, 30, 40, 90, 16, 16, 20, 60, 80 };
        displayGraph(values);
    }


    // Update is called once per frame
    //void Update()

    /*
     //create cirle
        create new game object, 
    setparent to gameobject = graphcontainer
    create bar
    ref to rectTransform
    set anchor position from one from the function
    recttranform.anchor max 
    "" min
    sizeDelta


        show graph list of values
    go thru list
        get max value
        x position
        y position (valuelist/ymax) * graphHeight
    calculate position of x and y axis
    x = time 
    float x = i * xSize(distance between each point in the graph
    define top of our graph
    height of graph = graph.sizeDelta.y
    create circle 
     
     
     */

    /*
     if users determine the length of the simulation, either by task or otherwise we can calculate x axis like 
    after x amount of time has passed, get current numInfected from Statistics Script, put in value list; 
        Add x axis labels
        Text Xaxis1;
        Text Xaxis2;
        Text Xaxis3;


        UnityEngine.Time
        private List<int> values;
        public Statistics stats;
        float timePassed; 
        float addInterval = 60f; (if our sim runs for 5 mins and each minute is a day, than this will be 1 minute)
        float time = Time.time;
    void Update(){
        if(time - timePassed >= addInterval){
            timePassed = time; 
            value.add(stats.numInfectedStat);
        }
     }
     */

    private void CreateBar(Vector2 setPosition, float width) {
        //create rectangle
        GameObject gameObject = new GameObject("rect", typeof(Image)); 
        gameObject.transform.SetParent(graphDisplay, false);
        gameObject.GetComponent<Image>();
        RectTransform barTransform = gameObject.GetComponent<RectTransform>();
        barTransform.anchoredPosition = new Vector2(setPosition.x, 0f);
        //anchor to bottom left
        barTransform.sizeDelta = new Vector2(width, setPosition.y);
        barTransform.anchorMin = new Vector2(0, 0);
        barTransform.anchorMax = new Vector2(0, 0);
        barTransform.pivot = new Vector2(.5f, 0f);
    }


    private void displayGraph(List<int> numInfected){
        //given the value, display it
        float graphHeight = graphDisplay.sizeDelta.y;
        //distance between bars
        float dist = 40f;
        int min = numInfected[0];
        int max = 0;
        for (int i = 0; i < numInfected.Count; i++)
        {
            float yPos = (numInfected[i] / 100f) * graphHeight; //100 should be replaced by maximum y value
            float xPos = dist+ i * dist;
            CreateBar(new Vector2(xPos, yPos), 20);

            //get max value for labels 
            if(numInfected[i] > max)
            {
                max = numInfected[i];
            }

            if(numInfected[i] < min)
            {
                min = numInfected[i];
            }
        }
        int mid = max - min;
        max += 10;
        YaxisTop.text = max.ToString();
        YaxisMid.text = mid.ToString();
        YaxisBot.text = min.ToString();
        //x axis will be time but how do we want to do that, like a set number of ways or what?

    }
}
