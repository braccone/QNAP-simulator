using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
    public string id;
    public float speed = 5.0f;
    
    public GameObject sezione;
    private Transform[] target;
    public int[] path;


    string tempoAttesa = "";
    GameObject colliso;
    float t;

    int i = 0;
    int k = 1;
    float oldAngle;

    private void Start()
    {
        //Debug.Log(sezione.transform.GetChild(i).position.x);
        //Debug.Log(sezione.name);

        target = new Transform[sezione.transform.childCount];
        for (int j=0; j < sezione.transform.childCount; j++)
        {
            //Debug.Log(j);
            target[j] = sezione.transform.GetChild(j);
        }
        //sezione = GameObject.Find("sezione");
        
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 direction = target[i].position - transform.position;
        //Vector2 direction = sezione.transform.Find("Fine").position - transform.position;
        // setta l'angolo di rotazione della macchina per farla sembrare che va in quel verso
        if (direction.y == 0f && direction.x != 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (direction.x == 0f && direction.y != 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if(direction.y == 0f && direction.x == 0f)
        {
            //Debug.Log(target[i].gameObject.name);
            if (i < target.Length-1)
            {
                i++;
               
            } else
            {
                //if (k < path.Length)
                //{
                speed = 0f;

                //CambiaSezione(/*path[k]*/);
                //if (GameObject.Find("sezione_" + path[k]))
                //{
                //    sezione = GameObject.Find("sezione_" + path[k]);
                //    target = new Transform[sezione.transform.childCount];
                //    for (int j = 0; j < sezione.transform.childCount; j++)
                //    {
                //        //Debug.Log(j);
                //        target[j] = sezione.transform.GetChild(j);
                //    }
                //    //i = 0;
                //if (k < path.Length - 1)
                //    k++;

                //}
                //}




            }
            transform.eulerAngles = new Vector3(0, 0, oldAngle);
        }
        else
        {
            float angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg ;
            if ( direction.x < 0)
            {
                angle = angle + 180f;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
            oldAngle = angle;
        }

        // serve per muovere la macchina verso il target di una certa velocità 
        transform.position = Vector2.MoveTowards(transform.position, target[i].position, speed * Time.deltaTime);
        if(float.TryParse(tempoAttesa, out t))
            t = t + 0.25f;
        if (tempoAttesa == t.ToString("f2"))
            colliso.GetComponent<CarMove>().speed = 3f;

        //transform.position = Vector2.MoveTowards(transform.position, sezione.transform.Find("Fine").position, speed * Time.deltaTime);
    }


    public void CambiaSezione(/*int id*/)
    {
        if (sezione)
        {
            //i = 0;
            //sezione = GameObject.Find("sezione_" + id);
            //Debug.Log(sezione.name);
            target = new Transform[sezione.transform.childCount];
            //Debug.Log(sezione.transform.childCount);
            for (int j = 0; j < sezione.transform.childCount; j++)
            {
                //Debug.Log(j);
                target[j] = sezione.transform.GetChild(j);
            }
            i = 0;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("macchina"))
        {
            tempoAttesa = GameObject.Find("timer").GetComponent<Timer>().testo.text;
            colliso = collision.gameObject;
            collision.gameObject.GetComponent<CarMove>().speed = 0f;

        }
    }
}
