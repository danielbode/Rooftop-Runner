using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {

	public GameObject highscoreAnzeige;
	public GameObject scoreAnzeige;
	private Text highscoreText;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		highscoreText = highscoreAnzeige.GetComponent<Text> ();
		scoreText = scoreAnzeige.GetComponent<Text> ();
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void aktualisieren()
	{

		highscoreText.text = PlayerPrefs.GetInt("highscore").ToString ();
		scoreText.text = Highscore.score.ToString ();

		
	}
}
