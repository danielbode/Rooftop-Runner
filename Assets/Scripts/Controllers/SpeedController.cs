using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float accelerationIncrease;
    public float accelerationIncreaseDuringInvincible;
    public int updatesPerAccelerationIncrease;

    private float currentAcceleration;
    private int numberOfUpdates;

    private void Start()
    {
        currentAcceleration = 1;
    }

    private void FixedUpdate()
    {
        numberOfUpdates++;
        if (numberOfUpdates == updatesPerAccelerationIncrease)
        {
            currentAcceleration += accelerationIncrease;
            numberOfUpdates = 0;
        }
    }

    public void StartInvincibleMode()
    {
        currentAcceleration += accelerationIncreaseDuringInvincible;
    }

    public void StopInvincibleMode()
    {
        currentAcceleration -= accelerationIncreaseDuringInvincible;
    }

    public float GetCurrentAcceleration()
    {
        return currentAcceleration;
    }
}
