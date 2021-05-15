using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    int dir = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection ()
    {
        dir *=-1;
    }


    void Update()
    {
        rb.velocity = new Vector2(0,12*dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
