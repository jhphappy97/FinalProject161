using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool isPaused = false;
    public Button restartButton;
    public Button resumeButton;

   // void Awake()
   // {
  //      pauseUI.SetActive(false);
   //     Time.timeScale = 1;
 //   }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {if(isPaused)

            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getHealth() < 1)
        {
            displayGameOver();
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
  
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void displayGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void restartLevel() {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Game"); }
}
