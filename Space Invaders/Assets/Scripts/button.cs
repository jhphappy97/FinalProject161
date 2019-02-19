using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button : MonoBehaviour
{
    public GameObject pauseUI;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    public void startGame()
    {
        Debug.Log("1");
        SceneManager.LoadScene("Game");
    }
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }
   
}
