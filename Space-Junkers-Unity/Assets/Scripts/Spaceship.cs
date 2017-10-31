using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    GameObject a,b;
    Rigidbody2D rb;
    public GameObject bullet;

    public float speed;
    public int health = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {

    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    public void Damage()
    {
        health--;
        if (health == 0)
            Destroy(gameObject);
    }

    void Shoot()
    {
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
 
}
