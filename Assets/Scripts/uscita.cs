using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uscita : MonoBehaviour {

    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        GameObject.Destroy(collision.gameObject);
    }
}
