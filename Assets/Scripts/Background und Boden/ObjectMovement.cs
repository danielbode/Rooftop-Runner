using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public enum ObjectType
    {
        Floor,
        Background
    }

    public GameObject GameControllerGameObject;
    private SpeedController SpeedController;
    private GameController GameController;
    private Rigidbody2D Rigidbody;
    public ObjectType Type;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        GameController = GameControllerGameObject.GetComponent<GameController>();
        SpeedController = GameControllerGameObject.GetComponent<SpeedController>();
    }

    void Update()
    {
        if (GameController.GetGameOn())
        {
            Move();
        }
    }

    public void Move()
    {
        float CurrentAcceleration = GameController.gameObject.GetComponent<SpeedController>().Acceleration;
        int Speed = 0;
        switch (Type)
        {
            case ObjectType.Floor:
                Speed = SpeedController.FloorSpeed;
                break;
            case ObjectType.Background:
                Speed = SpeedController.BackgroundSpeed;
                break;
        }
        Rigidbody.MovePosition(Rigidbody.position + CurrentAcceleration * Time.fixedDeltaTime * new Vector2(-1 * Speed, 0));
    }
}
