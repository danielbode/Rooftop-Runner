using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {

	private GameControl gameControl;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameControl = gameControllerObject.GetComponent <GameControl> ();
		}
		if (gameControl == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	public void pause()
	{
		gameControl.Pause ();
	}
}
