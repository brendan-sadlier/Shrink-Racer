using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public AudioSource deathSound;

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            deathSound.Play();
            // Restart the game
            Invoke(nameof(WaitAndShowGameOverScreen), restartDelay);
        }
    }

    void Restart ()
    {
        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void WaitAndShowGameOverScreen ()
    {
        // Show the game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
