using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject bullet,explotion, healthPick;
    public Color bulletColor;

    public float xSpeed;
    public float ySpeed;
    public float fireRate;
    public float health;
    public bool canShoot;
    public int score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 10);
        if (!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
            InvokeRepeating("Shoot", fireRate, fireRate);
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
        if((int)Random.Range(0,4)==0)
            Instantiate(healthPick, transform.position, Quaternion.identity);
        Instantiate(explotion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Destroy(gameObject);
		SoundManagerScript.PlaySound ("enemyDeath");
        }

    public void Damage()
    {
        health--;
        if (health == 0)
            Die();
    }

    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<BulletScript>().ChangeDirection();
		SoundManagerScript.PlaySound ("enemyShoot");
    }
}
