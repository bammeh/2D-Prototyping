using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeApplication : MonoBehaviour
{
    public Image pauseScreen;
    public Text gameOverScreen;
    Color pauseColor = new Color(0f, 0f, 0f, .9f);

    bool paused = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void togglePause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            pauseScreen.color = Color.clear;
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
            //Pause Screen
           pauseScreen.color = pauseColor;
            //Animator gameOverAnim = pauseScreen.GetComponent<Animator>();
            //gameOverAnim.SetTrigger("gameOver");
            
        }
    }
}
