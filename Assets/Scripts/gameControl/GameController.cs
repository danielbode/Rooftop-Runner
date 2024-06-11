﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public GameObject[] obstacles;
    public GameObject[] items;
    public GameObject bossMonster;

    public GameObject gameOverPanel;
    public GameObject neuerHighscore;

    public int initialLifes;

    private int counterBossmonster;
    private Animator playerAnimator;


    public GameObject score;
    private int lifes;

    //public Highscore highscore;


    // Use this for initialization
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetBool("gameOn", true);
        //highscore = new Highscore ();

        gameOverPanel.SetActive(false);
        neuerHighscore.SetActive(false);

        Time.timeScale = 1;
        StartCoroutine(CreateObstacles());
        StartCoroutine(CreateItems());
        //gameoverText.text = "";
        counterBossmonster = 0;
        lifes = initialLifes;
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
                int obstacleIndex = (int) Random.Range(0, obstacles.Length);
                Instantiate(obstacles[obstacleIndex], obstacles[obstacleIndex].transform.position, Quaternion.identity);
                float additionalTime = Random.value * 2; //wait up to 2 additional seconds to vary distance between obstacles
                yield return new WaitForSeconds(additionalTime + 1);
            }
        }
    }

    IEnumerator CreateItems()
    {
        yield return new WaitForSeconds(30);
        while (Time.timeScale != 0)
        {
            int itemIndex = (int) Random.Range(0, items.Length);
            Instantiate(items[itemIndex], items[itemIndex].transform.position, Quaternion.identity);
            float additionalTime = Random.value * 5;
            yield return new WaitForSeconds(additionalTime + 30);
        }
    }

    public void Gameover()
    {
        Time.timeScale = 0;
        lifes = 0;
        //gameoverText.text = "Game Over!";
        int aktuellerScore = score.GetComponent<Scoreboard>().getScore();
        if (aktuellerScore > PlayerPrefs.GetInt("highscore"))
        {
            neuerHighscore.SetActive(true);
        }
        Highscore.NeuerScore(aktuellerScore);
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<GameOverPanel>().aktualisieren();
    }

    public void Pause()
    {
        if (Time.timeScale != 0) {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
}
