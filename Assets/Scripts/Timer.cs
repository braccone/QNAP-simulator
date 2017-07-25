using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    float startTime;
    public List<int> incrocio1;
    string[][] vehicles;
    GameObject temp;
    public Text testo;
    // Use this for initialization
    void Start()
    {
        
        leggiFileSimulazione();
        startTime = Time.time;
        string ingresso = "";
        int k = 0;

        ////
        temp = GameObject.Find("Incrocio_2");
        //Debug.Log(/*vehicles[0].Length);*/
        //temp.transform.Find("ingresso_3").gameObject.GetComponent<ingresso>().CreateCar("M37");

        //(///

        //foreach(string[] row in vehicles)
        //{
        //    List<int> percorsoTemp = new List<int>();
        //    foreach (string element in row)
        //    {
        //        //Debug.Log(element);

        //        if (element !=null && !element.Contains("M"))
        //        {
        //            string[] val = element.Split('.');

        //            //Debug.Log(val[0]+"."+ val[1]+"."+ val[2]);
        //            if (val[1] == "2")
        //            {
        //                temp = GameObject.Find("Incrocio_2");
        //                if (val[0] == "2")
        //                {
        //                    int a;
        //                    if (int.TryParse(val[2],out a)){
        //                        //Debug.Log(a);
        //                        percorsoTemp.Add(a);
        //                        //continue;
        //                    } 
        //                }
        //                if (val[0] == "1")
        //                {
        //                    ingresso = "ingresso_" + val[2];
        //                    temp.transform.Find(ingresso).gameObject.GetComponent<ingresso>().CreateCar(k);
        //                    k++;
        //                    Debug.Log(ingresso);
        //                    //break;
        //                }
        //            }

        //        }
        //    }
        //    //temp = GameObject.Find("Incrocio_2");

        //    ////Debug.Log(temp.name);
        //    ////Debug.Log(ingresso);

        //    //if (ingresso != "")
        //    //{
        //    //    int[] prova = percorsoTemp.ToArray();
        //    //    //Debug.Log(prova);
        //    //    temp.transform.Find(ingresso).gameObject.GetComponent<ingresso>().CreateCar(k);
        //    //    k++;
        //    //}
        //    //if (k == 5)
        //    //{
        //    //    break;
        //    //}

        //}


    }
	// Update is called once per frame
	void FixedUpdate() {
        //Debug.Log(Time.time);

        float t = Time.time - startTime + 47f;
        string seconds = (t).ToString("f2");
        testo.text = seconds;
        ///prova con tempo
        ///
        /// 
        ///
        for(int i =0; i < vehicles.Length; i++)
        {
            if (vehicles[i][2].Contains(".2."))
            {
                //if (vehicles[i][1].Contains(seconds))
                //{
                //    //Debug.Log(vehicles[i][0]);
                //    temp.transform.Find("ingresso_" + vehicles[i][2].Split('.')[2]).gameObject.GetComponent<ingresso>().CreateCar(vehicles[i][0]);
                //}
                //if(GameObject.Find("macchina_" + vehicles[i][0]))
                //{
                for (int j = 1; j < vehicles[i].Length - 1; j = j + 2)
                {
                    //Debug.Log(seconds+"--"+ vehicles[i][j]);
                    if (vehicles[i][j].Contains(seconds))
                    {
                        if(vehicles[i][0] == "MD3")
                        {
                            Debug.Log(seconds + "==" + vehicles[i][j].Contains(seconds));
                        }
                        if (vehicles[i][j + 1].Contains("1."))
                        {
                            temp.transform.Find("ingresso_" + vehicles[i][j+1].Split('.')[j+1]).gameObject.GetComponent<ingresso>().CreateCar(vehicles[i][0]);
                        }
                        else
                        {
                            if (GameObject.Find("macchina_" + vehicles[i][0]))
                            {
                                GameObject.Find("macchina_" + vehicles[i][0]).GetComponent<CarMove>().speed = 5f;
                                GameObject.Find("macchina_" + vehicles[i][0]).GetComponent<CarMove>().sezione = GameObject.Find("sezione_" + vehicles[i][j + 1].Split('.')[2]);
                                GameObject.Find("macchina_" + vehicles[i][0]).GetComponent<CarMove>().CambiaSezione();
                            }
                        }
                        }
                        //Debug.Log(vehicles[i][j + 1]);
                        
                }
                //}
                
            }
        }
        
        //foreach (string[] row in vehicles)
        //{
        //    //debug.log(row[0]);
        //    if (float.parse(seconds) == float.parse(row[1].split('.')[0]) && cont == 0)
        //    {
        //        debug.log(row[1]);
        //        cont++;
        //        break;
        //        //temp.transform.find("ingresso_3").gameobject.getcomponent<ingresso>().createcar(row[0]);
        //    }
        //}



        ///
        //if (seconds == "6")
        //{
        //    if (GameObject.Find("macchina_M37"))
        //    {
        //        GameObject.Find("macchina_M37").GetComponent<CarMove>().speed = 0f;
        //        AssegnaSezione("M37",GameObject.Find("sezione_3"));
        //        //GameObject.Find("macchina_1").GetComponent<CarMove>().CambiaSezione();
        //    }

        //}

        //if (seconds == "10")
        //{
        //    if(GameObject.Find("macchina_M37"))
        //        GameObject.Find("macchina_M37").GetComponent<CarMove>().speed = 5.0f;
        //}

        //Debug.Log(seconds);
    }
    void AssegnaSezione(string id, /*int sezione,*/GameObject sezione)
    {
        GameObject temp = GameObject.Find("macchina_" + id);
        CarMove tempScript = temp.GetComponent<CarMove>();
        tempScript.sezione = sezione;
        tempScript.CambiaSezione();

    }
    void leggiFileSimulazione()
    {
        Debug.Log(Application.dataPath + "/SimulazioneNuovo.txt");
        if (File.Exists(Application.dataPath + "/SimulazioneNuovo.txt"))
        {
            
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
                    for (int i = 0; i <= lineWords.Length - 1; i++)
                    {
                        elementsPerRaw++;
                        //Debug.Log(lineWords[i]);
                    }
                    //Debug.Log(elementsPerRaw);
                    vehicles[numRiga] = new string[elementsPerRaw];
                    for (int i = 0; i < lineWords.Length - 1; i++)
                    {
                        if (lineWords[i].Length != 0)
                        {
                            vehicles[numRiga][numColonna] = lineWords[i];
                            //Debug.Log(vehicles[numRiga][numColonna]);
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
                    for (int i = 0; i < lineWords.Length - 2; i++)
                    {
                        elementsPerRaw++;
                    }

                    Array.Resize(ref vehicles[numRiga], vehicles[numRiga].Length + elementsPerRaw);
                    for (int i = 0; i < lineWords.Length - 2; i++)
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
                   
            //        if (element != null && !element.Contains("M"))
            //        {
            //            string[] temp = element.Split('.');
            //            // incrocio1 path macchina
            //            //if (temp[])
            //        }
            //        Debug.Log("L'array di indice " + k + " contiene " + element);
            //    }
            //    k++;
            //}

            //Debug.Log("Il numero di righe è "+vehiclesCounter);
        }
    }
}
