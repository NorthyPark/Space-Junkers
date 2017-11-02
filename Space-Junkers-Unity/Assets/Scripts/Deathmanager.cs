using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmanager : MonoBehaviour {

    GameObject players;
    bool gameOver = false;

	void Start ()
    {
        players = GameObject.FindGameObjectWithTag("Players");
	}
	
	void Update ()
    {
        if (players == null&&!gameOver)
            GameOver();
    }

    void GameOver()
    {
        gameOver = true;
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }

}
