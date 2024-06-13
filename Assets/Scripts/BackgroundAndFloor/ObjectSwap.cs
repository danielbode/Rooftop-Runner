using UnityEngine;

public class ObjectSwap : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;

    public float TurningPoint;

    void Update()
    {
        CheckAndUpdatePosition(Object1, Object2);
        CheckAndUpdatePosition(Object2, Object1);
    }

    void CheckAndUpdatePosition(GameObject obj1, GameObject obj2)
    {
        if (obj1.transform.position.x <= TurningPoint)
        {
            obj1.transform.position = obj2.transform.position - new Vector3(TurningPoint, 0, 0);
        }
    }
}
