using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Vector2 speed;
    public bool affectedByGameAcceleration;
    public bool destroyWhenOutOfView;

    private GameObject gameControllerGameObject;
    private SpeedController speedController;
    private Rigidbody2D rb2D;

    void Start()
    {
        gameControllerGameObject = GameObject.FindWithTag("GameController");
        if (gameControllerGameObject == null)
        {
            Debug.Log("Can not find Game Controller");
        }
        else
        {
            speedController = gameControllerGameObject.GetComponent<SpeedController>();
        }
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!destroyWhenOutOfView) return;
        if (other.CompareTag("spielfeld"))
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        float accelerationFactor = affectedByGameAcceleration ? speedController.Acceleration : 1;
        rb2D.MovePosition(rb2D.position + accelerationFactor * Time.fixedDeltaTime * speed);
    }
}
