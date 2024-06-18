using UnityEngine;

public class SwipeInputController : MonoBehaviour
{
    public int minSwipeDistance;

    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;
    private bool newTouch;
    private bool swiped;
    private Vector2 touchStart;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement not found.");
        }
        playerShooting = GetComponent<PlayerShooting>();
        if (playerShooting == null)
        {
            Debug.LogError("PlayerShooting not found.");
        }
    }

    private void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                newTouch = true;
                swiped = false;
                touchStart = touch.position;
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

    private void EvaluateSwipe(Vector2 touchCurrent)
    {
        if (!newTouch) return;

        float swipeY = touchCurrent.y - touchStart.y;

        if (Mathf.Abs(swipeY) >= minSwipeDistance)
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
