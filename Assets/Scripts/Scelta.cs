using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scelta : MonoBehaviour
{

    public Button incrocio1;
    public Button incrocio2;
    public Button incrocio3;
    // Use this for initialization
    void Start()
    {
        Button inc1 = incrocio1.GetComponent<Button>();
        inc1.onClick.AddListener(CliccatoIncrocio1);
        Button inc2 = incrocio2.GetComponent<Button>();
        inc2.onClick.AddListener(CliccatoIncrocio2);
        Button inc3 = incrocio3.GetComponent<Button>();
        inc3.onClick.AddListener(CliccatoIncrocio3);
    }

    void CliccatoIncrocio1()
    {
        Debug.Log("Hai cliccato il bottone del primo incrocio");
    }

    void CliccatoIncrocio2()
    {
        Debug.Log("Hai cliccato il bottone del secondo incrocio");
    }

    void CliccatoIncrocio3()
    {
        Debug.Log("Hai cliccato il bottone del terzo incrocio");
    }
}
