using UnityEngine;

public class DestroyMonster : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("monster"))
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

		if (other.CompareTag("hindernis")) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("monster")) {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
