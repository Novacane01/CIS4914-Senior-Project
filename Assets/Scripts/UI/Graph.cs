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
    Canvas canvas;
    public GameObject graphBG;
    private uint currentDay;
    private List<uint> infectedList = new List<uint>() { };
    private List<uint> susceptibleList = new List<uint>() { };
    private List<uint> immuneList = new List<uint>() { };
    private RectTransform XaxisLabelTmp;
    //Text txtDeaths;
    //Text txtPopulations;
    void Start(){
        graphDisplay = transform.Find("GraphDisplay").GetComponent<RectTransform>();
        YaxisTop = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisTop").GetComponent<Text>();
        YaxisMid = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisMid").GetComponent<Text>();
        YaxisBot = GameObject.Find("UI/StatsUI/Panel/Graph/YaxisBot").GetComponent<Text>();
        XaxisLabelTmp = graphDisplay.Find("XaxisLabel").GetComponent<RectTransform>();
        //create list of values to test 
        canvas = GameObject.Find("DailyReport").GetComponent<Canvas>();
        infectedList.Add(Statistics.numInfected);
        immuneList.Add(Statistics.numImmune);
        susceptibleList.Add(Statistics.currPop);
        displayGraph(infectedList, Color.red);
        displayGraph(immuneList, Color.green);
        displayGraph(susceptibleList, Color.blue);
        //displayGraph(values);
        currentDay = 0;

        NPCManager.instance.dayFinished.AddListener(() => {
            currentDay++;
            //days list -> make from config list? and just update here?
            //infected
            infectedList.Add(Statistics.numInfected);
            immuneList.Add(Statistics.numImmune);
            uint sus = Statistics.currPop - Statistics.numInfected;
            susceptibleList.Add(sus);
            displayGraph(infectedList, Color.red);
            displayGraph(immuneList, Color.green);
            displayGraph(susceptibleList, Color.blue);
        });
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


    //public static float infectionRate = 0.50f;
    /*
    c = avg # of contacts per day
    T = transmission rate = tranmission risk * avg number of interactions a day (average number of people an infected person passes the disease too
    infection period - how long are people contagious
    recovery rate - chance of survival = 1/ IP
    Population must be assigned
        infectious
        recovered/immune
     */



    void Update()
    {
        System.Random rnd = new System.Random();
        float r = rnd.Next(100) / 100f;

        //Debug.Log("CHANCE FOR DEATH");
        //Debug.Log(r);
    }

    private void CreateDot(Vector2 setPosition, Color dotColor) {
        //create rectangle
        GameObject gameObject = new GameObject("rect", typeof(Image)); 
        gameObject.transform.SetParent(graphDisplay, false);
        gameObject.GetComponent<Image>().color = dotColor;
        RectTransform barTransform = gameObject.GetComponent<RectTransform>();
        barTransform.anchoredPosition = setPosition;
        barTransform.sizeDelta = new Vector2(10,10);
        //barTransform.anchoredPosition = new Vector2(setPosition.x, 0f);
        //anchor to bottom left
        //barTransform.sizeDelta = new Vector2(width, setPosition.y);
        barTransform.anchorMin = new Vector2(0, 0);
        barTransform.anchorMax = new Vector2(0, 0);
        //barTransform.pivot = new Vector2(.5f, 0f);
    }


    private void displayGraph(List<uint> sirList, Color dotColor){
        //given the value, display it
        float graphHeight = graphDisplay.sizeDelta.y;
        //float graphWidth = graphDisplay.sizeDelta.x;
        //distance between bars
        float dist = 50f;
        uint min = 0;
        float max = Statistics.initPop;
        float mid = max/2;

        for (int i = 0; i < sirList.Count; i++)
        {
            float yPos = (sirList[i] / max) * graphHeight; //100 should be replaced by maximum y value
            float xPos = dist+ i * dist;
            CreateDot(new Vector2(xPos, yPos), dotColor);
            // Debug.Log("NEW VECTOR");
            //Debug.Log(xPos);
            //Debug.Log(yPos);
            //Debug.Log(sirList[i]);
            //Debug.Log(graphHeight);
            //get max value for labels 
            RectTransform XaxisLabel = Instantiate(XaxisLabelTmp);
            XaxisLabel.SetParent(graphDisplay,false);
            XaxisLabel.gameObject.SetActive(true);
            XaxisLabel.anchoredPosition = new Vector2(xPos, -10f);
            int x = i++;
            XaxisLabel.GetComponent<Text>().text = x.ToString();
        }

        YaxisTop.text = max.ToString();
        YaxisMid.text = mid.ToString();
        YaxisBot.text = min.ToString();
        //x axis will be time but how do we want to do that, like a set number of ways or what?

    }
}
