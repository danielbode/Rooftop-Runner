using UnityEngine;
using System.Collections;

public class MonsterShooting : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot()
	{
		yield return new WaitForSeconds (1);
		while (true) {
			Instantiate (bullet, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (1.5f);
		}
	}
}
