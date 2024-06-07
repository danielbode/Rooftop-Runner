using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Highscore : MonoBehaviour {

	//static List<int> highscore = new List<int> ();
	public static int highscore;
	public static int score;

	
	public static void NeuerScore(int neu)
	{
		highscore = PlayerPrefs.GetInt ("highscore");

		if (neu > highscore)
		{
			highscore = neu;
			PlayerPrefs.SetInt ("highscore", highscore);
		}

		score = neu;



			
	}

}
