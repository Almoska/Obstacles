using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public Transform tr,intezo_tr,restart_menu;
    public RectTransform pause_button;
    public bool moveAllowed, szamlal, egyszer;
    public Collider2D cd;
    public int szamlalo, best_score;
    public Text szamlalo_text,your_score,high_score;
    public LayerMask fogaskerek_akadaly;
    public SpriteRenderer cukisag_sprite_renderer;
    public Sprite egyik_sprite, masik_sprite, harmadik_sprite, negyedik_sprite,ghost_sprite;
    public string ez;
    public int jelenlegi;
    public string szereplo;
    public int s_x, s_y;
    public int lehetosegek;
    public Text lehet;
    public RectTransform b1, b2, b3,b4,b5, t1,t2,t3;
    public Image c_c;
    // Start is called before the first frame update
    public void Start()
    {
        cd = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        alapallas();
        szamlal = true;
        ez = "ewfhihwiefef";
        cukisag_sprite_renderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("jelenlegi") == 1) {
            cukisag_sprite_renderer.sprite = egyik_sprite;
                }
        if(PlayerPrefs.GetInt("jelenlegi") == 2)
        {
            cukisag_sprite_renderer.sprite = masik_sprite;
        }
        if(PlayerPrefs.GetInt("jelenlegi") == 3)
        {
            cukisag_sprite_renderer.sprite = harmadik_sprite;
        }
        if(PlayerPrefs.GetInt("jelenlegi") == 4)
        {
            cukisag_sprite_renderer.sprite = negyedik_sprite;
        }
        if(PlayerPrefs.GetInt("jelenlegi") == 5)
        {
            cukisag_sprite_renderer.sprite = ghost_sprite;
        }
        szereplo = cukisag_sprite_renderer.sprite.name;
        s_x = Screen.width;
        s_y = Screen.height;
        if(s_x == 720 && s_y == 1280 || s_y < 1560 && s_y > 1200 && s_y < 1600)
        {
            pause_button.position = new Vector3(606, 120, 0);
            szamlalo_text.GetComponent<RectTransform>().position = new Vector3(160, 120, 0);
        };
        if(s_x > 1000 && s_y >= 1600 && s_y < 2900)
        {
            pause_button.position = new Vector3(900, 160, 0);
            szamlalo_text.GetComponent<RectTransform>().position = new Vector3(200, 100, 0);
            pause_button.localScale = new Vector3(1.2f, 1.2f, 1);
            c_c.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);
            t1.position = new Vector3(540, 1180, 0);
            t1.localScale = new Vector3(1.2f, 1.2f, 1);
            t2.localScale = t1.localScale;
            t2.position = new Vector3(540, 1330, 0);
            b1.localScale = new Vector3(1.2f, 1.2f, 0);
            b2.localScale = new Vector3(1.2f, 1.2f, 0);
            b3.localScale = new Vector3(1.2f, 1.2f, 0);
            b4.localScale = new Vector3(1.2f, 1.2f, 0);
            b5.localScale = new Vector3(1.2f, 1.2f, 0);
            b3.position = new Vector3(540, 1000, 1);
            b5.position = new Vector3(540, 740, 1);
            b4.position = new Vector3(540, 480, 1);
        }
        if(s_x > 1200 && s_y >= 2900)
        {
            pause_button.position = new Vector3(1200, 300, 0);
            pause_button.localScale = new Vector3(2, 2, 1);
            szamlalo_text.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            szamlalo_text.GetComponent<RectTransform>().position = new Vector3(280, 200, 0);
            b1.localScale = new Vector3(2,2,0);
            b2.localScale = new Vector3(2, 2, 0);
            b3.localScale = new Vector3(2, 2, 0);
            b4.localScale = new Vector3(2, 2, 0);
            b5.localScale = new Vector3(2, 2, 0);
            b3.position = new Vector3(720, 1800, 0);
            b5.position = new Vector3(720, 906, 0);
            c_c.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);
            t1.position = new Vector3(720, 2200, 0);
            t1.localScale = new Vector3(2, 2, 1);
            t2.localScale = t1.localScale;
            t2.position = new Vector3(720, 2400, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cukisag_sprite_renderer.GetComponentInParent<Transform>().position.x < -2.75)
        {
            cukisag_sprite_renderer.GetComponentInParent<Transform>().position = new Vector3(-2, 0, 1);
        }
        if (cukisag_sprite_renderer.GetComponentInParent<Transform>().position.x > 2.75)
        {
            cukisag_sprite_renderer.GetComponentInParent<Transform>().position = new Vector3(2, 0, 1);
        }
        szamlalo_text.text = Mathf.FloorToInt(szamlalo).ToString();
        if(szamlal == true) { szamlalo = szamlalo + 1; }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if (cd == touchCollider)
                {
                    moveAllowed = true;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
        if (cd.IsTouchingLayers(fogaskerek_akadaly))
        {
            szamlal = false;
            intezo_tr.GetComponentInParent<intezo>().f_spawn();
            pause_button.gameObject.SetActive(false);
            if (egyszer == false)
            {
                restart_menu.gameObject.SetActive(true);
                egyszer = true;
            }
            Time.timeScale = 0f;
            your_score.gameObject.SetActive(true);
            if(PlayerPrefs.GetInt("best_score") < szamlalo)
            PlayerPrefs.SetInt("best_score", szamlalo);
            Debug.Log(PlayerPrefs.GetInt("best_score"));
            high_score.text = "Your best score " + PlayerPrefs.GetInt("best_score").ToString();
            your_score.text = "your score " + szamlalo;
            lehet.text = PlayerPrefs.GetInt("lehetosegek").ToString()+" to the ad";
        }

    }
    public void alapallas()
    {
        Time.timeScale = 1f;
        szamlalo = 0;
        restart_menu.gameObject.SetActive(false);
        pause_button.gameObject.SetActive(true);
        your_score.gameObject.SetActive(false);
        szamlal = true;
        egyszer = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        egyszer = false;
        if(cukisag_sprite_renderer.sprite == egyik_sprite)
        {
            PlayerPrefs.SetInt("jelenlegi", 1);
        }
        if(cukisag_sprite_renderer.sprite == masik_sprite)
        {
            PlayerPrefs.SetInt("jelenlegi", 2);
        }
        if(cukisag_sprite_renderer.sprite == harmadik_sprite)
        {
            PlayerPrefs.SetInt("jelenlegi", 3);
        }
        if(cukisag_sprite_renderer.sprite == negyedik_sprite)
        {
            PlayerPrefs.SetInt("jelenlegi", 4);
        }
        if(cukisag_sprite_renderer.sprite == ghost_sprite)
        {
            PlayerPrefs.SetInt("jelenlegi", 5);
        }
    }
    public void tovabb_el()
    {
        alapallas();
        intezo_tr.GetComponentInParent<intezo>().f_spawn();
        intezo_tr.GetComponentInParent<intezo>().fogaskerek1.GetComponentInParent<fogaskerek>().Start();
        intezo_tr.GetComponentInParent<intezo>().fogaskerek2.GetComponentInParent<fogaskerek>().Start();
        intezo_tr.GetComponentInParent<intezo>().fogaskerek3.GetComponentInParent<fogaskerek>().Start();
    }
}
