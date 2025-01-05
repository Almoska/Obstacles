using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ellenorzo : MonoBehaviour
{
    public Transform monster;
    public SpriteRenderer mo;
    public Sprite cuki_szorny, cukisag, harmadik, hastag, ghost;
    public Text eleres;
    public int kell,kell2,kell3,kell4;

    public void beallitas()
    {
        kell = 100;
        kell2 = 600;
        kell3 = 1000;
        kell4 = 1400;
    }
    public void valtas()
    {
        if (PlayerPrefs.GetInt("best_score") > 100)
        {
            mo.sprite = cuki_szorny;
        }
        else
        {
            eleres.gameObject.SetActive(true);
        }
    }
    public void masik_valtas()
    {
        if (PlayerPrefs.GetInt("best_score") > 600)
        {
            mo.sprite = harmadik;
        }
    }
    public void negyedik()
    {
        if(PlayerPrefs.GetInt("best_score") > 1000)
        {
            mo.sprite = hastag;
        }
    }
    public void otodik()
    {
        if (PlayerPrefs.GetInt("best_score") > 1399)
        {
            mo.sprite = ghost;
        }
    }
    public void levonas()
    {
        PlayerPrefs.SetInt("osszes", PlayerPrefs.GetInt("osszes") - kell);
    }
}
