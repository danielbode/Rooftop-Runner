using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;
    public GameObject gameOverPannel;
    public GameObject newHighscoreBadge;
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

    public void UpdateScoreAfterGameOver()
    {
        gameOverScoreText.text = score.ToString();
        int currentHighscore = PlayerPrefs.GetInt("highscore");
        if (score > currentHighscore)
        {
            gameOverHighScoreText.text = score.ToString();
            PlayerPrefs.SetInt("highscore", score);
            newHighscoreBadge.SetActive(true);
        }
        else
        {
            gameOverHighScoreText.text = currentHighscore.ToString();
        }
        gameOverPannel.SetActive(true);

    }
}
