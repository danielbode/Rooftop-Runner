using UnityEngine;

public class SwipeInputController : MonoBehaviour {

	public int minSwipeDistance;

	private Vector2 touchStart;
	private bool newTouch;
	private bool swiped;

	private PlayerMovement playerMovement;
	private PlayerShooting playerShooting;

	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<PlayerMovement>();
		playerShooting = GetComponent<PlayerShooting>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 0) return;
		
		var touch = Input.GetTouch(0);

		switch(touch.phase)
		{
		case TouchPhase.Began:
			touchStart = touch.position;
			newTouch = true;
			swiped = false;
			break;
			
		case TouchPhase.Moved:
			EvaluateSwipe(touch.position);
			break;
			
		case TouchPhase.Ended:
			newTouch = false;
			if (!swiped) { Touch(); }
			break;

		case TouchPhase.Canceled:
			newTouch = false;
			if (!swiped) { Touch(); }
			break;
		}
	}

	private void EvaluateSwipe(Vector2 touchNow)
	{
		if(!newTouch) return;
				
		var swipeY = touchNow.y - touchStart.y;

		if (Mathf.Abs (swipeY) >= minSwipeDistance) 
		{
			if (swipeY > 0) { SwipeUp(); }
			if (swipeY < 0) { SwipeDown(); }

			newTouch = false;
			swiped = true;
		}
	}

	private void SwipeUp()
    {
		playerMovement.OnJump();
    }

	private void SwipeDown()
    {
		playerMovement.OnDuck();
    }

	private void Touch()
    {
		playerShooting.OnShoot();
    }
}
