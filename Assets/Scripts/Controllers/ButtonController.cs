using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        if (!SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            GameObject gameControllerGameObject = GameObject.FindWithTag("GameController");
            if (gameControllerGameObject == null)
            {
                Debug.LogError("Game Object with tag \"GameController\" not found.");
            }
            else
            {
                gameController = gameControllerGameObject.GetComponent<GameController>();
                if (gameController == null)
                {
                    Debug.LogError("GameController not found.");
                }
            }
        }
    }

    public void Pause()
    {
        gameController.TogglePause();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Highscore()
    {
        SceneManager.LoadSceneAsync("Highscore");
    }
}
