using UnityEngine;
using System.Collections;

public class swipeEingabe : MonoBehaviour {

	private Vector2 touchStart;
	private bool newTouch;
	public bool swipeNachRechts;
	public bool swipeNachLinks;
	public bool swipeNachOben;
	public bool swipeNachUnten;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 0) return; //Abbrechen bei 0 Touches
		
		var touch = Input.GetTouch(0);

		switch(touch.phase)
		{
		case TouchPhase.Began:
			touchStart = touch.position;
			newTouch = true; //wir können jetzt wischen
			break;
			
		case TouchPhase.Moved:
			EvaluateSwipe(touch.position);
			break;
			
		case TouchPhase.Ended:
			newTouch = false;
			break;

		case TouchPhase.Canceled:
			newTouch = false;
			break;
		}
	}

	private void EvaluateSwipe(Vector2 touchNow)
	{
		if(!newTouch) return; //Abbrechen, wenn das aktuelle Wischen schon ein Mal zum Spurwechsel geführt hat
		
		float swipeWidth = 40; 
		float swipeHeight = 40;
		
		var swipeX = touchNow.x - touchStart.x; //Der "Wisch-Vektor"
		var swipeY = touchNow.y - touchStart.y;
		
		if(Mathf.Abs(swipeX) >= swipeWidth)
		{
			swipeNachRechts = swipeX > 0; //true, wenn nach rechts gewischt wurde, links wäre false
			swipeNachLinks = swipeX < 0;
						
			newTouch = false; // Dieses Wischen ist "verbraucht" und man muss neu Wischen um noch einmal bewegen zu können
		}

		if (Mathf.Abs (swipeY) >= swipeHeight) 
		{
			swipeNachOben = swipeY > 0;
			swipeNachUnten = swipeY < 0;

			newTouch = false;
		}
	}
}
