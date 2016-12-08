using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeApplication : MonoBehaviour
{

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
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
        }
    }
}
