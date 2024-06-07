using UnityEngine;
using System.Collections;

public class playerSchuss : MonoBehaviour {

	public Transform schuss;
	private int timer;
	private GameController gameControl;
	private swipeEingabe swipe;
	public int schussAnzahl;

	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameController>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		swipe = GetComponent<swipeEingabe> ();

		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameControl.GetGameOn()) {
			schiessen ();
		}

	}

	void schiessen()
	{
		if (swipe.swipeNachRechts || Input.GetKey(KeyCode.Space) ) 
		{
			if(timer % 50 == 0 && schussAnzahl > 0)
			{
				Instantiate (schuss, new Vector2 (this.transform.position.x + 1, this.transform.position.y ), Quaternion.identity);
				timer++;
				swipe.swipeNachRechts = false;
				schussAnzahl--;
			}
			timer++;
		}else{
			timer = 0;
		}

	}

	public void PatronenAuffuellen()
	{
		schussAnzahl = 10;
	}




}
