using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public DisplayBullets displayBullets;
    public GameObject bullet;
    public float shootCooldown;
    public int maxNumberOfBullets;
    public int currentNumberOfBullets;

    private GameController gameController;
    private float lastShootTime;

    private void Start()
    {
        GameObject gameControllerGameObject = GameObject.FindWithTag("GameController");
        if (gameControllerGameObject == null)
        {
            Debug.LogError("Game Object with tag \"GameController\" not found.");
        }
        else
        {
            gameController = gameControllerGameObject.GetComponent<GameController>();
            if (gameController == null)
            {
                Debug.LogError("GameController not found.");
            }
        }

        currentNumberOfBullets = maxNumberOfBullets;
    }

    public void OnShoot()
    {
        if (Time.time - lastShootTime < shootCooldown) return;
        if (Time.timeScale != 0 && currentNumberOfBullets > 0)
        {
            Instantiate(bullet, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
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
