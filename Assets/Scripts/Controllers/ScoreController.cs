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

    private bool playerInvincible;
    private int score;
    private int numberOfUpdates;

    private void Start()
    {
        playerInvincible = false;
    }

    private void FixedUpdate()
    {
        numberOfUpdates++;
        if (numberOfUpdates > (playerInvincible ? updatesNeededForPointInvincible : updatesNeededForPointRegular))
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

    public void StartInvincibleMode()
    {
        playerInvincible = true;
    }

    public void StopInvincibleMode()
    {
        playerInvincible = false;
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
