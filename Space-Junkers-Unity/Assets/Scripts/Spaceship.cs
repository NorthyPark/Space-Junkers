using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    int delay = 0;
    GameObject a,b;
    Rigidbody2D rb;
    public GameObject bullet,explotion;
	public AudioClip explosionDeath;

    public float speed;
    public int health = 3;

	private AudioSource source;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
		source = GetComponent<AudioSource> ();

    }

    void Start()
    {
        PlayerPrefs.SetInt("Health", health);
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

		if (Input.GetKey (KeyCode.Space) && delay > 10)
			Shoot ();
		
	
		

        delay++;
    }

    public void Damage()
    {
		SoundManagerScript.PlaySound ("entetyHit");
		health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
		if (health == 0)
        {
			SoundManagerScript.PlaySound ("playerDeath");

			Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(gameObject, .1f);
        }

			


    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    void Shoot()
    {
		SoundManagerScript.PlaySound ("playerShoot");
		delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
 
}
