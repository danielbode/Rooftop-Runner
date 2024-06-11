using UnityEngine;
using System.Collections;

public class Movement_Hindernisse : MonoBehaviour {

	//public float speed;
	public Vector2 velocity;
	public Rigidbody2D rb2D;
	private GameController gameControl;
	public bool geschwVeraenderung;


	//public bool IstSchuss;

	//private bool gameOn;
	// Use this for initialization

	void Start ()
	{

		rb2D = GetComponent<Rigidbody2D>();



		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameController>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	
		//gameOn = gameControl.GetGameOn();
	
	}
	

	void OnTriggerExit2D(Collider2D other) //hindernisse werden beim verlassen des spielfelds zerstört
	{
		if(other.tag == "spielfeld")
		{
			Destroy(this.gameObject);
		}

	}




	void FixedUpdate ()
	{
		float g = 1;

		if (geschwVeraenderung) 
		{
			g = gameControl.gameObject.GetComponent<SpeedController> ().Acceleration;
		}

			rb2D.MovePosition (rb2D.position + velocity* g * Time.fixedDeltaTime);
	}
	


}
