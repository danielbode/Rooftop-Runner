using UnityEngine;
using System.Collections;

public class monsterSchuss : MonoBehaviour {

	public Transform schuss;
	private GameController gameControl;

	// Use this for initialization
	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameControl = gameControllerObject.GetComponent <GameController>();
		}
		if (gameControl == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		StartCoroutine (Schiessen ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Schiessen()
	{

		yield return new WaitForSeconds (1);
		while (gameControl.GetGameOn()) {
			Instantiate (schuss, this.transform.position, Quaternion.identity);
			yield return new WaitForSeconds (1.5f);
		}
	}

}
