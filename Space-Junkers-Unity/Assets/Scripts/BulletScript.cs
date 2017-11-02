using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    int dir=1;

	Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    public void ChangeDirection ()
    {
        dir^=-1;
	}

	
	void Update ()
    {
        rb.velocity = new Vector2(0,12*dir);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Player Bullet
        if (dir == 1) {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemies>().Damage();
                Destroy(gameObject);
            }
            }else{
        if (col.gameObject.tag == "Players")
            {
                col.gameObject.GetComponent<Spaceship>().Damage();
                Destroy(gameObject);
            }
        }

    }
}
