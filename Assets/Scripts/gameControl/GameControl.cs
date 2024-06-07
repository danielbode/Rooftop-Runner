using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	Animator run;
	public int anzahlHindernisse;
	public Transform[] hindernisse;
	public Transform[] items;
	public int anzahlItems;
	public Transform monster;

	public GameObject gameOverPanel;
	public GameObject neuerHighscore;


	private int auswahlHoM;

	public GameObject score;
	public int leben;


	//public Highscore highscore;



	// Use this for initialization
	void Start()
	{
		run = GetComponent<Animator>();
		//highscore = new Highscore ();


		gameOverPanel.SetActive (false);
		neuerHighscore.SetActive (false);

		run.SetBool("gameOn", true);
		StartCoroutine(Hindernisse());
		StartCoroutine(ItemsErzeugen());
		//gameoverText.text = "";
		auswahlHoM = 0;
		leben = 1;


	}
	// Update is called once per frame

	void Update () {


	}

	IEnumerator Hindernisse()
	{
		yield return new WaitForSeconds (1);
		while (run.GetBool("gameOn")) 
		{

			if(auswahlHoM == 10)
			{
				Instantiate (monster);
				yield return new WaitForSeconds (1);
				auswahlHoM = 0;
			}else
            {
                
				auswahlHoM++; 
				int ii = (int) Random.Range(0,anzahlHindernisse);
				Instantiate(hindernisse[ii], hindernisse[ii].position, Quaternion.identity);
				float zufall = Random.value * 2;
				yield return new WaitForSeconds (zufall +1);

			}


		}
	}

	IEnumerator ItemsErzeugen()
	{
		yield return new WaitForSeconds (30);
		while (run.GetBool("gameOn"))
		{
			int ii = (int) Random.Range(0,anzahlItems);
			Instantiate(items[ii], items[ii].position, Quaternion.identity);
			float zufall = Random.value * 5;
			yield return new WaitForSeconds (zufall +30);

		}
	}



	public void Gameover()
	{
		run.SetBool("gameOn", false);
		//gameoverText.text = "Game Over!";
		int aktuellerScore = score.GetComponent<Scoreboard>().getScore();
		if (aktuellerScore > PlayerPrefs.GetInt ("highscore"))
		{
			neuerHighscore.SetActive(true);
		}
		Highscore.NeuerScore (aktuellerScore);
		gameOverPanel.SetActive (true);
		gameOverPanel.GetComponent<GameOverPanel> ().aktualisieren ();

		leben = 0;


	}

	//wird von pauseButton aufgerufen wenn der button gedrückt wird
	public void Pause()
	{
		if (leben > 0) 
		{
			if (run.GetBool("gameOn")) {
				run.SetBool("gameOn", false);
			} else {
				StartCoroutine (Unpause ());

			}
		}
	}


	public bool GetGameOn()
	{
		return run.GetBool("gameOn");
	}

	IEnumerator Unpause()
	{
		yield return new WaitForSeconds (0.2f);
		run.SetBool("gameOn", true);
		StopCoroutine (Hindernisse ());		//um Fehler zu vermeiden, dass keine hindernisse mehr erzeugt werden
		StartCoroutine (Hindernisse ());
	}






}
