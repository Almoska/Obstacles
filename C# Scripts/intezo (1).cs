using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intezo : MonoBehaviour
{
    public Transform fogaskerek1, fogaskerek2, fogaskerek3,cukisag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void f_spawn()
    {
        fogaskerek1.transform.GetComponentInParent<fogaskerek>().Start();
        fogaskerek2.transform.GetComponentInParent<fogaskerek>().Start();
        fogaskerek3.transform.GetComponentInParent<fogaskerek>().Start();
    }
    public void fomenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void pause()
    {
        Time.timeScale = 0f;
        cukisag.transform.GetComponentInParent<control>().szamlal = false;
    }
    public void tovabb()
    {
        Time.timeScale = 1f;
        cukisag.transform.GetComponentInParent<control>().szamlal = true;
    }
}
