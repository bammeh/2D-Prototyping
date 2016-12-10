using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);

    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void characterSelect()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }

    public void quitGame()
    {
        Application.Quit();
    }

    //Character Selection Buttons
    public void chooseCharacter(int id)
    {
        PlayerPrefs.SetInt("character", id);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void rollCredits()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
