using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        GameObject temp = GameObject.Find("Incrocio_1");
        temp.transform.Find("ingresso_1").gameObject.GetComponent<ingresso>().CreateCar(4);
    }
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        string seconds = (t % 60).ToString("f0");
        Debug.Log(seconds);
	}
}
