using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Timer : MonoBehaviour {
    float startTime;
    public List<int> incrocio1;
    string[][] vehicles;
    // Use this for initialization
    void Start()
    {
        GameObject temp;
        leggiFileSimulazione();
        startTime = Time.time;
        string ingresso = "";
        int k = 0;
        

        foreach(string[] row in vehicles)
        {
            List<int> percorsoTemp = new List<int>();
            foreach (string element in row)
            {
                //Debug.Log(element);
                if (!element.Contains("M"))
                {
                    string[] val = element.Split('.');
                    if (val[1] == "3")
                    {
                        //temp = GameObject.Find("Incrocio_3");
                        if (val[0] == "1")
                        {
                            ingresso = "ingresso_" + val[2];
                        }
                        if (val[0] == "2")
                        {
                            int a;
                            if (int.TryParse(val[2],out a)){
                                //Debug.Log(a);
                                percorsoTemp.Add(a);
                            }
                            
                            
                        }
                    }
                    
                }
            }
            temp = GameObject.Find("Incrocio_3");

            //Debug.Log(temp.name);
            //Debug.Log(ingresso);

            if (ingresso != "")
            {
                int[] prova = percorsoTemp.ToArray();
                //Debug.Log(prova);
                temp.transform.Find(ingresso).gameObject.GetComponent<ingresso>().CreateCar(k, prova);
                k++;
            }
            if (k == 5)
            {
                break;
            }
                
        }
        

    }
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        string seconds = (t % 60).ToString("f0");
        //Debug.Log(seconds);
	}

    void leggiFileSimulazione()
    {
        Debug.Log(Application.dataPath + "/SimulazioneNuovo.txt");
        if (File.Exists(Application.dataPath + "/SimulazioneNuovo.txt"))
        {
            Debug.Log("sono entrato");
            int vehiclesCounter = 0;
            int elementsPerRaw = 0;
            char firstChar;
            int numRiga = 0, numColonna = 0;

            foreach (string line in File.ReadAllLines(Application.dataPath+ "/SimulazioneNuovo.txt"))
            {
                if (line.ToCharArray()[0] == 'M')
                {

                    vehiclesCounter++;

                }
            }

            vehicles = new string[vehiclesCounter][];
            foreach (string line in File.ReadAllLines(Application.dataPath + "/SimulazioneNuovo.txt"))
            {
                firstChar = line.ToCharArray()[0];
                if (firstChar == 'M')
                {

                    numColonna = 0;
                    var lineWords = line.Split(' ');
                    for (int i = 0; i < lineWords.Length - 2; i = i + 2)
                    {
                        elementsPerRaw++;
                    }

                    vehicles[numRiga] = new string[elementsPerRaw];
                    for (int i = 0; i < lineWords.Length - 2; i = i + 2)
                    {
                        if (lineWords[i].Length != 0)
                        {
                            vehicles[numRiga][numColonna] = lineWords[i];
                            numColonna++;
                        }

                    }

                    numRiga++;
                    elementsPerRaw = 0;
                }
                else
                {
                    numRiga--;
                    var lineWords = line.Split(' ');
                    for (int i = 0; i < lineWords.Length - 2; i = i + 2)
                    {
                        elementsPerRaw++;
                    }

                    Array.Resize(ref vehicles[numRiga], vehicles[numRiga].Length + elementsPerRaw);
                    for (int i = 0; i < lineWords.Length - 2; i = i + 2)
                    {
                        if (lineWords[i].Length != 0)
                        {
                            vehicles[numRiga][numColonna] = lineWords[i];
                            numColonna++;
                        }

                    }
                    numRiga++;
                    numColonna = 0;
                }
                elementsPerRaw = 0;
            }

            //int k = 0;
            //foreach (String[] row in vehicles)
            //{
            //    foreach (String element in row)
            //    {
            //        if (!element.Contains("M"))
            //        {
            //            string[] temp = element.Split('.');
            //            // incrocio1 path macchina
            //            if(temp[])
            //        }
            //        Debug.Log("L'array di indice "+k+" contiene "+element);
            //    }
            //    k++;
            //}

            Debug.Log("Il numero di righe è "+vehiclesCounter);
        }
    }
}
