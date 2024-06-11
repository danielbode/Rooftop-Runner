using UnityEngine;
using System.Collections;

public class monsterMovement : MonoBehaviour {

	public Rigidbody2D rb;
	private GameController gameControl;
	public Vector2 velocity;
	private int timer;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameController>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale != 0) {
			//StartCoroutine (bewegung ());
			bewegung ();
		}
	}

	void bewegung()
	{
		timer++;
		if(this.transform.position.x > 6)
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);

		}
		else
		{

			rb.MovePosition(rb.position);
			//yield return new WaitForSeconds(1.5f);
			if(timer > 400)
			{
				velocity.y = 3; 
				rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
			}
		}
	}

}
