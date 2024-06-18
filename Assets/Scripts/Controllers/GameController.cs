using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] items;
    public GameObject bossMonster;
    public float staticTimeBetweenObstacles;
    public float staticTimeBetweenItems;

    private Animator playerAnimator;
    private ScoreController scoreController;
    private int counterBossmonster;
    private bool gameOver;

    private void Start()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject == null)
        {
            Debug.LogError("Game Object with tag \"Player\" not found.");
        }
        else
        {
            playerAnimator = playerGameObject.GetComponent<Animator>();
            if (playerAnimator == null)
            {
                Debug.LogError("PlayerAnimator not found.");
            }
            else
            {
                playerAnimator.SetBool("gameOn", true);
            }
        }
        scoreController = GetComponent<ScoreController>();
        if (scoreController == null)
        {
            Debug.LogError("ScoreController not found.");
        }

        Time.timeScale = 1;
        counterBossmonster = 0;

        StartCoroutine(CreateObstacles());
        StartCoroutine(CreateItems());
    }

    private IEnumerator CreateObstacles()
    {
        yield return new WaitForSeconds(staticTimeBetweenObstacles);
        while (Time.timeScale != 0)
        {
            if (counterBossmonster == 10)
            {
                Instantiate(bossMonster);
                yield return new WaitForSeconds(staticTimeBetweenObstacles);
                counterBossmonster = 0;
            }
            else
            {
                counterBossmonster++;
                int obstacleIndex = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[obstacleIndex], obstacles[obstacleIndex].transform.position, Quaternion.identity);
                float additionalTime = Random.value * 2; //wait up to 2 additional seconds to vary distance between obstacles
                yield return new WaitForSeconds(additionalTime + staticTimeBetweenObstacles);
            }
        }
    }

    private IEnumerator CreateItems()
    {
        yield return new WaitForSeconds(staticTimeBetweenItems);
        while (Time.timeScale != 0)
        {
            int itemIndex = Random.Range(0, items.Length);
            Instantiate(items[itemIndex], items[itemIndex].transform.position, Quaternion.identity);
            float additionalTime = Random.value * 5;
            yield return new WaitForSeconds(additionalTime + staticTimeBetweenItems);
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
