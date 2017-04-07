﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;
    Bounce bounce;
    public GameObject thePlayerContainer;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");

        hidePaused();
        hideGameOver();

        if (SceneManager.GetActiveScene().name == "Prototype")
        {
            Debug.Log("In the main scene");
            //bounce = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Bounce>();
            bounce = thePlayerContainer.GetComponent<Bounce>();
            Debug.Log("The player is alive: " + bounce.alive);
        }

	}
	
	// Update is called once per frame
	void Update () {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1 && bounce.alive == true)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0 && bounce.alive == true)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        // shows Game Over gameObjects if player is dead and timescale = 0

        if (Time.timeScale == 0 && bounce.alive == false)
        {
            Debug.Log("Player died.");
            showGameOver();
        }
    }
	
    // Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene("Prototype", LoadSceneMode.Single);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnGameOver tag
    public void showGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnGameOver tag
    public void hideGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

}
