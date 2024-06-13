using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public GameObject[] obstacles;
    public GameObject[] items;
    public GameObject bossMonster;

    public GameObject gameOverPanel;
    public GameObject neuerHighscore;

    public GameObject score;

    private int counterBossmonster;
    private Animator playerAnimator;
    private ScoreController scoreController;

    private bool gameOver;

    // Use this for initialization
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetBool("gameOn", true);

        scoreController = GetComponent<ScoreController>();

        gameOverPanel.SetActive(false);
        neuerHighscore.SetActive(false);

        Time.timeScale = 1;

        counterBossmonster = 0;

        StartCoroutine(CreateObstacles());
        StartCoroutine(CreateItems());
    }

    IEnumerator CreateObstacles()
    {
        yield return new WaitForSeconds(1);
        while (Time.timeScale != 0)
        {
            if (counterBossmonster == 10)
            {
                Instantiate(bossMonster);
                yield return new WaitForSeconds(1);
                counterBossmonster = 0;
            }
            else
            {
                counterBossmonster++;
                int obstacleIndex = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[obstacleIndex], obstacles[obstacleIndex].transform.position, Quaternion.identity);
                float additionalTime = Random.value * 2; //wait up to 2 additional seconds to vary distance between obstacles
                yield return new WaitForSeconds(additionalTime + 1);
            }
        }
    }

    IEnumerator CreateItems()
    {
        yield return new WaitForSeconds(1);
        while (Time.timeScale != 0)
        {
            int itemIndex = Random.Range(0, items.Length);
            Instantiate(items[itemIndex], items[itemIndex].transform.position, Quaternion.identity);
            float additionalTime = Random.value * 5;
            yield return new WaitForSeconds(additionalTime + 30);
        }
    }
    public void TogglePause()
    {
        if (gameOver) return;
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Gameover()
    {
        gameOver = true;
        Time.timeScale = 0;
        scoreController.UpdateScoreAfterGameOver();
    }
}
