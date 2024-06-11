using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {

	private GameController gameControl;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameControl = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameControl == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	public void pause()
	{
		gameControl.TogglePause ();
	}
}
