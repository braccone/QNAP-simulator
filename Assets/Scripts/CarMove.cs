using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
    public float speed = 2.0f;
    public GameObject[] target;
    int i = 0;
    float oldAngle;
    // Update is called once per frame
    void FixedUpdate() {
        Vector2 direction = target[i].transform.position - transform.position;

        // setta l'angolo di rotazione della macchina per farla sembrare che va in quel verso
        if(direction.y == 0f && direction.x != 0f)
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
        transform.position = Vector2.MoveTowards(transform.position, target[i].transform.position, speed * Time.deltaTime);
    }
}
