using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Players")
            col.gameObject.GetComponent<Spaceship>().AddHealth();
            Destroy(gameObject);
    }
}
