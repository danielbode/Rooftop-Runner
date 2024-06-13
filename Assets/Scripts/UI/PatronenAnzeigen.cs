using UnityEngine;

public class PatronenAnzeigen : MonoBehaviour {

	public Transform[] patronen;
	public PlayerShooting schuss;
	public Transform patrone;
	public int patronenAnzahl;
	private int maxPatronen;

	// Use this for initialization
	void Start () {

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			schuss = playerObject.GetComponent <PlayerShooting>();
		}
		if (schuss == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		maxPatronen = schuss.currentNumberOfBullets;
		patronenAnzahl = schuss.currentNumberOfBullets;

		patronen = new Transform[schuss.currentNumberOfBullets];

		for (int i = 0; i < maxPatronen; i++)
		{
			patronen [i] = Instantiate (patrone, new Vector3 (8.8f - (0.6f * (float)i), -5.5f, 0), Quaternion.identity) as Transform;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (patronenAnzahl > schuss.currentNumberOfBullets) {

			patronenAktualisieren ();
		}

		if(patronenAnzahl < schuss.currentNumberOfBullets)
		{
			neuePatronen();
		}

	
	}

	public void patronenAktualisieren()
	{
		for (int ii = maxPatronen -1; ii >= 0; ii--) 
		{
			if( ii >= schuss.currentNumberOfBullets)
			{

				patronen[ii].gameObject.SetActive(false);
			
				patronenAnzahl = schuss.currentNumberOfBullets;
			}
		}
	}

	public void neuePatronen()
	{
		for (int i = 0; i < maxPatronen; i++)
		{
			patronen [i].gameObject.SetActive(true);
		}

		patronenAnzahl = schuss.currentNumberOfBullets;
	}

}
