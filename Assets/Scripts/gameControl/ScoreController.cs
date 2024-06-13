using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public int updatesNeededForPointRegular;
    public int updatesNeededForPointInvincible;

    private GameObject gameControllerGameObject;
    private SpeedController speedController;
    private int score;
    private int numberOfUpdates;

    private void Start()
    {
        gameControllerGameObject = GameObject.FindWithTag("GameController");
        speedController = gameControllerGameObject.GetComponent<SpeedController>();
    }

    private void FixedUpdate()
    {
        numberOfUpdates++;
        if (numberOfUpdates > (speedController.getUnsterblich() ? updatesNeededForPointInvincible : updatesNeededForPointRegular))
        {
            score++;
            numberOfUpdates = 0;
            scoreText.text = "Points: " + score;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
