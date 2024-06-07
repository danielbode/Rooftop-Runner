using UnityEngine;
using System.Collections;

public class BackgroudBewegung : MonoBehaviour {

	public Rigidbody2D rb;
	private GameControl gameControl;
	public float speed;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameControl>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		
		
	}

	void Update () {
		if (gameControl.GetGameOn ()) {
			Move ();
		} else {
			DontMove ();
		}
	}

	public void Move()
	{
		float g = gameControl.gameObject.GetComponent<Geschwindigkeitskontrolle> ().geschwindigkeit;

		rb.MovePosition (rb.position + new Vector2 (speed, 0) * g * Time.fixedDeltaTime);
	}
	
	public void DontMove()
	{
		rb.MovePosition (rb.position);
	}
}
