using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingresso : MonoBehaviour
{
    public GameObject prefab;
    public int id;
    public GameObject sezione;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("CreateCar", 0.0f, 2f);
        //CreateCar(4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCar(int id, int[] path)
    {
        GameObject temp = (GameObject)Instantiate(prefab,this.transform.position,Quaternion.identity);
        //Debug.Log(this.transform.parent.gameObject.name);
        temp.GetComponent<CarMove>().id = id;
        temp.GetComponent<CarMove>().sezione = sezione;
        temp.name = "macchina_" + id;
        temp.GetComponent<CarMove>().path = new int[path.Length];
        temp.GetComponent<CarMove>().path = path;
    }
}