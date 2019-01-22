using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public float restartDelay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level
    private PlayerV2 playerAccess;
    public GameObject player_script;
    public GameObject gameOverBackground;
    public GameObject gameOverText;

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        playerAccess = player_script.GetComponent<PlayerV2>();
        gameOverBackground.SetActive(false);
        gameOverText.SetActive(false);
    }


    void Update()
    {
        // If the player has run out of health...
        if (playerAccess.getHealth() < 1)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
            gameOverBackground.SetActive(true);
            gameOverText.SetActive(true);

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}