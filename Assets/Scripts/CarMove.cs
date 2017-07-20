using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
    public int id;
    public float speed = 2.0f;
    
    public GameObject sezione;
    private Transform[] target;

    int i = 0;
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
            
            if (i < target.Length-1)
            {
                i++;
            } else
            {
                if(GameObject.Find("sezione_" + (sezione.GetComponent<Sezione>().id + 1)))
                {
                    sezione = GameObject.Find("sezione_" + (sezione.GetComponent<Sezione>().id + 1));
                    target = new Transform[sezione.transform.childCount];
                    for (int j = 0; j < sezione.transform.childCount; j++)
                    {
                        //Debug.Log(j);
                        target[j] = sezione.transform.GetChild(j);
                    }
                    i = 0;
                }
                
                transform.eulerAngles = new Vector3(0, 0, oldAngle);

            }
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
        //transform.position = Vector2.MoveTowards(transform.position, sezione.transform.Find("Fine").position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(speed > 0f)
        {
            speed = 0f;
        }
    }

    //private GameObject getChildObject(GameObject oggetto, string name)
    //{
    //    GameObject[] figli = oggetto.GetComponentsInChildren();
    //    return null;
    //}
}
