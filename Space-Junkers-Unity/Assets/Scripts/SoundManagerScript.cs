using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip entityHitSound, playerDeathSound, enemyDeathSound, playerShootSound, playerHealSound, enemyShootSound;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		entityHitSound = Resources.Load<AudioClip> ("entityHit");
		playerDeathSound = Resources.Load<AudioClip> ("playerDeath");
		enemyDeathSound = Resources.Load<AudioClip> ("enemyDeath");
		playerShootSound = Resources.Load<AudioClip> ("playershoot");
		playerHealSound = Resources.Load<AudioClip> ("heal");
		enemyShootSound = Resources.Load<AudioClip> ("enemyShoot");

		audioSrc = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip)
	{
		switch (clip) 
		{
		case "entityHit":
			audioSrc.PlayOneShot (entityHitSound);
			break;
		case "playerDeath":
			audioSrc.PlayOneShot (playerDeathSound);
			break;

		case "enemyDeath":
			audioSrc.PlayOneShot (enemyDeathSound);
			break;

		case "playerShoot":
			audioSrc.PlayOneShot (playerShootSound);
			break;

		case "heal":
			audioSrc.PlayOneShot (playerHealSound);
			break;

		case "enemyShoot":
			audioSrc.PlayOneShot (enemyShootSound);
			break;
			
		}
	}
}
