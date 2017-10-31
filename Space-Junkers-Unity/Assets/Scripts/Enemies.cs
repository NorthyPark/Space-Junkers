using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public float fireRate;
    public float health;
    public bool canShoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {




    }


    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Players")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }
    void Die()
        {
            Destroy(gameObject);
        }
}
