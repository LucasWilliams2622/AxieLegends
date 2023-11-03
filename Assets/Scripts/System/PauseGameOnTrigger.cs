using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameOnTrigger : MonoBehaviour
{

    public PauseGameController pauseControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void goMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void continueGame()
    {
        pauseControl.pauseGame();
    }

}
