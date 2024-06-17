using UnityEngine;

public class SpeedController : MonoBehaviour
{

    public float Acceleration;
    private int i;

    // Use this for initialization
    void Start()
    {
        Acceleration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        i++;
        if (i == 500)
        {
            Acceleration += 0.05f;
            i = 0;
        }
    }

    public void StartInvincibleMode()
    {
        Acceleration += 3;
    }

    public void StopInvincibleMode()
    {
        Acceleration -= 3;
    }
}
