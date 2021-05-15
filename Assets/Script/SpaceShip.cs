using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    int delay = 0;
    GameObject a, b;
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    int health = 3;
    public Text Victoria;
    public Text Derrota;
    float timeLeft = 15.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;

    }


    void Start()
    {
        
    }


    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetKey(KeyCode.Space) && delay > 10)
            Shoot();

        delay++;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    public void Damage()
    {
        health--;
        if (health == 0)
            SceneManager.LoadScene("Derrota");
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
}
