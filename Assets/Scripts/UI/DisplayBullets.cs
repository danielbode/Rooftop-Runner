using UnityEngine;

public class DisplayBullets : MonoBehaviour {

	public GameObject[] bullets;
	private PlayerShooting playerShooting;
	public GameObject bullet;
	private int maxBullets;

	// Use this for initialization
	void Start () {

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			playerShooting = playerObject.GetComponent<PlayerShooting>();
		}
		if (playerShooting == null)
		{
			Debug.Log ("Cannot find 'PlayerShooting' script");
		}

		maxBullets = playerShooting.maxNumberOfBullets;

		bullets = new GameObject[playerShooting.maxNumberOfBullets];

		for (int i = 0; i < maxBullets; i++)
		{
			bullets[i] = Instantiate (bullet, new Vector2 (8.8f - (0.6f * (float)i), -5.5f), Quaternion.identity);
			bullets[i].transform.SetParent(transform);
		}
	}
	
	public void UpdateBullets()
	{
		for (int i = 0; i < playerShooting.currentNumberOfBullets; i++)
		{
			bullets[i].SetActive(true);
		}

		for (int i = playerShooting.currentNumberOfBullets; i < playerShooting.maxNumberOfBullets; i++)
		{
			bullets[i].SetActive(false);
		}
	}
}
