using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerShooting : MonoBehaviour
{
    public Transform bullet;

    public GameObject bulletsDisplay;

    private GameController gameControl;
    private DisplayBullets displayBullets;

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

        displayBullets = bulletsDisplay.GetComponent<DisplayBullets>();

        currentNumberOfBullets = maxNumberOfBullets;
    }

    public void OnShoot()
    {
        if (Time.time - lastShootTime < shootCooldown) return;
        if (Time.timeScale != 0 && currentNumberOfBullets > 0)
        {
            Instantiate(bullet, new Vector2(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
            currentNumberOfBullets--;
        }
        lastShootTime = Time.time;
        displayBullets.UpdateBullets();
    }

    public void RefillBullets()
    {
        currentNumberOfBullets = maxNumberOfBullets;
        displayBullets.UpdateBullets();
    }
}
