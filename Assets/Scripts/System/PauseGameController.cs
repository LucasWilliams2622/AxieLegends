using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameController : MonoBehaviour
{
    public GameObject pausegame;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            trigger = !trigger;
        }

    }

    void CheckPause()
    {
        if (trigger)
        {
            pausegame.SetActive(true);
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }
        else
        {
            pausegame.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
    }
}
