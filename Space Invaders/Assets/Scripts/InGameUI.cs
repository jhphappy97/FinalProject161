using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject pauseUI;
    bool isPaused = false;
    public Button restartButton;
    public Button resumeButton;

    void Awake()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getHealth() < 1)
            displayGameOver();
    }

    public void TogglePause()
    {
        print("Pause!");
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
            restartButton.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }
    public void quit()
    {
        Application.Quit();
    }

    public void displayGameOver()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        restartButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
    public void restartLevel() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
