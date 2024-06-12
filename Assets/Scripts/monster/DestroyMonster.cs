using UnityEngine;

public class DestroyMonster : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("monster")) {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag("hindernis"))
		{
			Destroy(gameObject);
		}
	}
}
