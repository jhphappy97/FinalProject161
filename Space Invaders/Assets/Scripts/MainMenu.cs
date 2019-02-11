using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetAxis("Submit") > 0)
            startGame();
    }



    public void startGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void quitgame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
