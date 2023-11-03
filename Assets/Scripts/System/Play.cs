using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public bool isTrigger;

    private void Start()
    {
        isTrigger = false;
    }

    private void Update()
    {
        if (isTrigger)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
    public void  PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScenetest");
    }

    public void MuteSound()
    {
        isTrigger = !isTrigger;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
