using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	private int score;
	public Text scoreText;
	private int scoreZeit;
	public GameObject gameControl;

	// Use this for initialization
	void Update () {
		if (Time.timeScale != 0) {
			scoreZaehlen ();
		}
	}

	/*
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "hindernis" || other.tag == "monster")
		{
			score = score + 1;
			GUIscore.text = ("Punkte: " + score);
		}

	}*/

	void scoreZaehlen()
	{
		scoreZeit++;
		int wannScoreDazu = 20;

		if(gameControl.gameObject.GetComponent<SpeedController>().getUnsterblich())
		{
			wannScoreDazu = 1;
		}

		if (scoreZeit > wannScoreDazu)
		{
			score++;
			scoreZeit = 0;
			scoreText.text = ("Punkte: " + score);
		}
		
	}

	public int getScore()
	{
		return score;

	}
}
