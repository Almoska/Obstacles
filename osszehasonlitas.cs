using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class osszehasonlitas : MonoBehaviour
{
    public Text egy, ketto, harom, negy, ot;
    public Transform mirol;
    public Color myColor;
    

    public void nezes()
    {
        mirol.GetComponent<ellenorzo>().beallitas();
        myColor = new Color(35f, 240f, 10f, 100f);
        ketto.text = PlayerPrefs.GetInt("best_score").ToString() + "/" + mirol.GetComponent<ellenorzo>().kell;
        harom.text = PlayerPrefs.GetInt("best_score").ToString() + "/" + mirol.GetComponent<ellenorzo>().kell2;
        negy.text = PlayerPrefs.GetInt("best_score").ToString() + "/" + mirol.GetComponent<ellenorzo>().kell3;
        ot.text = PlayerPrefs.GetInt("best_score").ToString() + "/" + mirol.GetComponent<ellenorzo>().kell4;
    }
}
