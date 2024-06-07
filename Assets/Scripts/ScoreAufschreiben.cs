using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreAufschreiben : MonoBehaviour {

	public Text text;
	//public Transform controller;
	//public Transform[] t;


	// Use this for initialization
	void Start () 
	{

		//text = t.gameObject.GetComponent<Text>();


		schreiben ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void schreiben()
	{
		List<int> score = GetComponent<Highscore>().GetScore();
		int anzahl = score.Count;
		Debug.Log (anzahl.ToString ());
		int[] scoreArray = score.ToArray ();

		for (int i = 0; i < anzahl; i++)
		{
			text = t[i].gameObject.GetComponent<Text>();
			text.text = scoreArray[i].ToString();

		}


	}
*/

	void schreiben()
	{
		text.text = PlayerPrefs.GetInt("highscore").ToString();
	}


}
