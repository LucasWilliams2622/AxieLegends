using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameOnTrigger : MonoBehaviour
{
    public Button exit;
    public Button menu;
    public Button resume;
    public PauseGameController pauseControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exit.onClick.AddListener(exitGame);
        menu.onClick.AddListener(goMenu);
        resume.onClick.AddListener(continueGame);
    }
    void exitGame()
    {
        Application.Quit();
    }
    void goMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    void continueGame()
    {
        pauseControl.trigger = false;
    }

}
