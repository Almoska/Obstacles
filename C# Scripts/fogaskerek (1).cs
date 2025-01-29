using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogaskerek : MonoBehaviour
{

    public Transform fogaskerek_tr;
    public Rigidbody2D rb;
    public float x_pos, nagysag, szam, szam2, velocity_nagysag, noveles, z_pos,x_p,y_p;
    public bool monster,nehez_menni;
    // Start is called before the first frame update
    public void Start()
    {
        fogaskerek_tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        szam = 0.4f;
        szam2 = 0.6f;
        if(monster == false)
        {
            velocity_nagysag = -4;
            noveles = -0.004f;
            z_pos = 1;
        }
        else
        {
            velocity_nagysag = -2.4f;
            noveles = -0.0024f;
            z_pos = 2;
        }
        fogaskerek_tr.position = new Vector2(x_p, y_p);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, velocity_nagysag);
        velocity_nagysag = velocity_nagysag + noveles;
        if(transform.position.y < -7)
        {
            Spawn();
        }
        if(nehez_menni == true)
        {
            rb.gravityScale = 2;
        }
        if(monster == false)
        transform.Rotate(0, 0, 6);
    }
    public void Spawn()
    {
        x_pos = Random.Range(-2, 2);
        nagysag = Random.Range(szam,szam2);
        fogaskerek_tr.position = new Vector2(x_pos, 7);
        fogaskerek_tr.localScale = new Vector3(nagysag, nagysag, z_pos);
    }
}
