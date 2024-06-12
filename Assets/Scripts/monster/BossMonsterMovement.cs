using UnityEngine;
using System.Collections;

public class BossMonsterMovement : MonoBehaviour {

	public Rigidbody2D rb;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		while (transform.position.x > 6)
		{
			yield return null;
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
		yield return new WaitForSeconds(7);
		while (true)
		{
			yield return null;
			velocity.y = 3;
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}
}
