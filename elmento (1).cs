using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class elmento : MonoBehaviour
{
    public Transform tr;
    public int pont_szam;
    // Start is called before the first frame update
    void Start()
    {
        pont_szam = tr.GetComponentInParent<control>().szamlalo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
