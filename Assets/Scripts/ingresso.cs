using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingresso : MonoBehaviour
{
    public GameObject prefab;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("CreateCar", 0.0f, 1f);
        CreateCar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCar()
    {
        GameObject temp = (GameObject)Instantiate(prefab);
        //Debug.Log(this.transform.parent.gameObject.name);
        temp.GetComponent<CarMove>().sezione = this.transform.parent.gameObject;
    }
}