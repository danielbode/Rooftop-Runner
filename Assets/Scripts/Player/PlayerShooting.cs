using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerShooting : MonoBehaviour
{
    public Transform bullet;

    private GameController gameControl;

    public float shootCooldown;
    public int maxNumberOfBullets;
    public int currentNumberOfBullets;
    private float lastShootTime;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControl = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControl == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        currentNumberOfBullets = maxNumberOfBullets;
    }

    public void OnShoot(CallbackContext callbackContext)
    {
        if (Time.time - lastShootTime < shootCooldown) return;
        if (gameControl.GetGameOn() && currentNumberOfBullets > 0)
        {
            Instantiate(bullet, new Vector2(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
            currentNumberOfBullets--;
        }
        lastShootTime = Time.time;
    }

    public void RefillBullets()
    {
        currentNumberOfBullets = maxNumberOfBullets;
    }
}
