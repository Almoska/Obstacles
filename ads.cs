using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour
{
    public void ad()
    {
        if(PlayerPrefs.GetInt("lehetosegek") < 1)
        {
            PlayerPrefs.SetInt("lehetosegek", PlayerPrefs.GetInt("lehetosegek") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("lehetosegek", 0);
        }
    }
}
