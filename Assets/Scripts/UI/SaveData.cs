using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    public void saveData()
    {
        string path = @"C:\Users\Ashley\Documents\test.txt";
        if (!File.Exists(path))
        {
            using(StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(Statistics.numDays);
                sw.WriteLine(Statistics.transRate);
                sw.WriteLine(Statistics.numInfected);
                sw.WriteLine(Statistics.numImmune);
                sw.WriteLine(Statistics.numDeaths);
            
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
                sw.WriteLine(Statistics.numDays);
                sw.WriteLine(Statistics.transRate);
                sw.WriteLine(Statistics.numInfected);
                sw.WriteLine(Statistics.numImmune);
                sw.WriteLine(Statistics.numDeaths);
            }
        }
    }

    // Update is called once per frame

}
