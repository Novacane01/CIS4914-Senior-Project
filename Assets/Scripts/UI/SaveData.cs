using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{

    public Transform contentWindow;
    public Text text;

    public void saveData()
    {
        string path = Application.dataPath;
        path = path +"/data.txt";
        Debug.Log(path);
        if (!File.Exists(path))
        {
            using(StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Number of Days: " + Statistics.numDays);
                sw.WriteLine("Transmission Rate: " + Statistics.transRate);
                sw.WriteLine("Final Number Infected: " + Statistics.numInfected);
                sw.WriteLine("Final Number Immune: " + Statistics.numImmune);
                sw.WriteLine("Final Number of Deaths " + Statistics.numDeaths + Environment.NewLine);
            
            }

            using(StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Number of Days: " + Statistics.numDays);
                sw.WriteLine("Transmission Rate: " + Statistics.transRate);
                sw.WriteLine("Final Number Infected: " + Statistics.numInfected);
                sw.WriteLine("Final Number Immune: " + Statistics.numImmune);
                sw.WriteLine("Final Number of Deaths " + Statistics.numDeaths + Environment.NewLine);
            }
        }
    }

    public void viewData()
    {
        string path = Application.dataPath + "/data.txt";
        Debug.Log(path);
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                s += s;
            }
        }
        string dataContents = File.ReadAllText(path);
        Debug.Log(dataContents);
        text.text = dataContents;
        Instantiate(text, contentWindow);
    }
}
