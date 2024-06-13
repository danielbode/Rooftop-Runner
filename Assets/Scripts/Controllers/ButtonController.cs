using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private GameObject gameControllerGameObject;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerGameObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerGameObject.GetComponent<GameController>();
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
