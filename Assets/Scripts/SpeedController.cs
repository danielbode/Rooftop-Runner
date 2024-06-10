using UnityEngine;

public class SpeedController : MonoBehaviour
{

    public float Acceleration;
    public int FloorSpeed;
    public int BackgroundSpeed;
    private int i;
    private bool unsterblich;

    // Use this for initialization
    void Start()
    {
        Acceleration = 1;
        unsterblich = false;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i == 500)
        {
            Acceleration += 0.05f;
            i = 0;
        }

    }

    public void extraGeschw()
    {
        unsterblich = true;
        Acceleration += 3;
    }

    public void extraGeschwEnde()
    {
        unsterblich = false;
        Acceleration -= 3;
    }

    public bool getUnsterblich()
    {
        return unsterblich;
    }

}
