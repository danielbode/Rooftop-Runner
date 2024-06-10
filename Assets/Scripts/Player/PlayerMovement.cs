using UnityEngine;
using System.Collections;
using static UnityEngine.InputSystem.InputAction;
using System;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb2D;
	private GameController gameControl;

	public float jumpForce;
	public float jumpCooldown;
	private int jumpCount;
	private float lastJumpTime;

	public float duckForce;
	public float duckDuration;
	private bool isDucked;

	public Vector3 initialPlayerScale;
	public Vector3 miniPlayerScale;

	private int unsterblich;
	private playerSchuss schuss;

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

		schuss = GetComponent<playerSchuss> ();
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "roof") // immer wenn trigger am boden berührt wird wird zahl wieder auf 0 gesetzt damit wieder gesprungen werden kann
		{
			jumpCount = 0;
		}

		if (other.tag == "hindernis" || other.tag == "monster") //man stirbt wenn man den trigger von hindernissen oder monstern berührt
		{
			if(unsterblich == 0)
			{
				gameControl.Gameover();
			}
		}

		if (other.tag == "unsterblich") 
		{
			unsterblichMode();
			Destroy(other.gameObject);
		}

		if (other.tag == "patronen") 
		{
			schuss.PatronenAuffuellen ();
			Destroy(other.gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D other)	// monster wird zerstört wenn man von oben draufspringt
	{
		if (other.gameObject.tag == "monster") {
			Destroy (other.gameObject);
		}

	}

	void Update() 
	{
		if (unsterblich > 0) 
		{
			unsterblich++;
		}

		if (unsterblich == 300) 
		{
			unsterblichModeEnde();
			//unsterblich = 0;
		}

		if (unsterblich > 350)
		{
			unsterblich = 0;
			//GetComponent<PolygonCollider2D> ().enabled = true;
		}
	}

	public void OnJump(CallbackContext callbackContext)
	{

		if (Time.time - lastJumpTime < jumpCooldown) return;
		if (gameControl.GetGameOn() && jumpCount < 2)
		{
			if (isDucked)
			{
				isDucked = false;
				this.transform.localScale = initialPlayerScale;
			}
			rb2D.velocity = new Vector2(0, jumpForce);
			jumpCount++;
		}
		lastJumpTime = Time.time;
	}

	public void OnDuck(CallbackContext callbackContext)
	{
		if (gameControl.GetGameOn())
		{
			isDucked = true;
			this.transform.localScale = miniPlayerScale;
			rb2D.velocity = new Vector2(0, duckForce);
			StartCoroutine(DoAfterDelay(duckDuration, () =>
			{
				if (!this.transform.localScale.Equals(initialPlayerScale))
				{
					transform.localScale = initialPlayerScale;
				}
			}));
		}
	}

	public void unsterblichMode()
	{
		unsterblich = 1;
		rb2D.velocity = new Vector2(0, jumpForce); 
		transform.position = new Vector3 (-6.5f, 1, 0);

		rb2D.isKinematic = true;
		gameControl.gameObject.GetComponent<SpeedController> ().extraGeschw ();
		//rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
		//GetComponent<PolygonCollider2D> ().enabled = false;
	}

	public void unsterblichModeEnde()
	{
		if (unsterblich == 300)
		{
			rb2D.isKinematic = false;
			gameControl.gameObject.GetComponent<SpeedController> ().extraGeschwEnde();
			//transform.position = new Vector3 (-6.5f, -3, 0);
			/*rb2D.constraints = RigidbodyConstraints2D.None;

			rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
			*/
		}


	}

	IEnumerator DoAfterDelay(float delaySeconds, Action thingToDo)
	{
		yield return new WaitForSeconds(delaySeconds);
		thingToDo();
	}
}
