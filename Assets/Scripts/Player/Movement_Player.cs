using UnityEngine;
using System.Collections;

public class Movement_Player : MonoBehaviour {

	public Rigidbody2D rb2D;
	public Vector2 kraft;
	private int zahl;
	private GameControl gameControl;

	private swipeEingabe swipe;
	private int geduckt;
	private int unsterblich;
	private playerSchuss schuss;


	void Start () 
	{
		rb2D = GetComponent<Rigidbody2D>();


		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameControl>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		swipe = GetComponent<swipeEingabe> ();
		schuss = GetComponent<playerSchuss> ();


	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "roof") // immer wenn trigger am boden berührt wird wird zahl wieder auf 0 gesetzt damit wieder gesprungen werden kann
		{
			zahl = 0;
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
		if (gameControl.GetGameOn () ) {
			springen ();
			ducken ();
		}

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

	/*//springen indem Kraft auf den Player einwirkt
	void springen()
	{
		if (Input.GetKeyUp (KeyCode.Mouse0) && zahl == 0)
		{
			rb2D.AddForce (kraft, ForceMode2D.Force);
			zahl ++;
		} else if (Input.GetKeyUp (KeyCode.Mouse0) && zahl == 1) 
		{
			rb2D.AddForce (kraft / 1.5f, ForceMode2D.Force);
			zahl ++;
		}
	}*/

	//springen indem eine Beschleunigung übertragen wird. Vorteil: auch wenn 
	//der player herunterfällt springt er noch nach oben
	void springen()
	{
		if (Input.GetKeyDown (KeyCode.S) && zahl < 2)
		{
			if(geduckt > 0)
			{
				geduckt = 0;
				this.transform.localScale = new Vector3 (0.25f, 0.25f, 1);
			}
			rb2D.velocity = kraft; 
			zahl ++;
		} 

		if (swipe.swipeNachOben && zahl < 2)
		{
			if(geduckt > 0)						// aufstehen wenn man während der player geeduckt ist springt
			{
				geduckt = 0;
				this.transform.localScale = new Vector3 (0.25f, 0.25f, 1);
			}
			rb2D.velocity = kraft; 
			zahl ++;
			swipe.swipeNachOben = false;
		}

	
	}

	void ducken()
	{
		if (geduckt > 0) {
			geduckt++;
		}

		if (swipe.swipeNachUnten || Input.GetKey (KeyCode.D)) {
			geduckt = 1;
			this.transform.localScale = new Vector3(0.25f,0.15f,1);
			if(zahl == 0)
			{
				this.transform.position = new Vector3(-6.5f,-3.5f,0);
			}
			swipe.swipeNachUnten = false;

		}

		if (geduckt > 40) {
			geduckt = 0;
			this.transform.localScale = new Vector3 (0.25f, 0.25f, 1);
			this.transform.position = new Vector3(-6.5f,-3f,0);
		}
	}

	public void unsterblichMode()
	{
		unsterblich = 1;
		rb2D.velocity = kraft; 
		transform.position = new Vector3 (-6.5f, 1, 0);

		rb2D.isKinematic = true;
		gameControl.gameObject.GetComponent<Geschwindigkeitskontrolle> ().extraGeschw ();
		//rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
		//GetComponent<PolygonCollider2D> ().enabled = false;
	}

	public void unsterblichModeEnde()
	{
		if (unsterblich == 300)
		{
			rb2D.isKinematic = false;
			gameControl.gameObject.GetComponent<Geschwindigkeitskontrolle> ().extraGeschwEnde();
			//transform.position = new Vector3 (-6.5f, -3, 0);
			/*rb2D.constraints = RigidbodyConstraints2D.None;

			rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
			*/
		}


	}

}