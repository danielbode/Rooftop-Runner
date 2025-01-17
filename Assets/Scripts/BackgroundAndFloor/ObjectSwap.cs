using UnityEngine;

public class ObjectSwap : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    public float TurningPoint;

    void Update()
    {
        CheckAndUpdatePosition(object1, object2);
        CheckAndUpdatePosition(object2, object1);
    }

    void CheckAndUpdatePosition(GameObject obj1, GameObject obj2)
    {
        if (obj1.transform.position.x <= TurningPoint)
        {
            obj1.transform.position = obj2.transform.position - new Vector3(TurningPoint, 0, 0);
        }
    }
}
