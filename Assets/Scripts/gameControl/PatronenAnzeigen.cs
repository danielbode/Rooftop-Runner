using UnityEngine;
using System.Collections;

public class PatronenAnzeigen : MonoBehaviour {

	public Transform[] patronen;
	public playerSchuss schuss;
	public Transform patrone;
	public int patronenAnzahl;
	private int maxPatronen;

	// Use this for initialization
	void Start () {

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			schuss = playerObject.GetComponent <playerSchuss>();
		}
		if (schuss == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		maxPatronen = schuss.schussAnzahl;
		patronenAnzahl = schuss.schussAnzahl;

		patronen = new Transform[schuss.schussAnzahl];

		for (int i = 0; i < maxPatronen; i++)
		{
			patronen [i] = Instantiate (patrone, new Vector3 (8.8f - (0.6f * (float)i), -5.5f, 0), Quaternion.identity) as Transform;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (patronenAnzahl > schuss.schussAnzahl) {

			patronenAktualisieren ();
		}

		if(patronenAnzahl < schuss.schussAnzahl)
		{
			neuePatronen();
		}

	
	}

	public void patronenAktualisieren()
	{
		for (int ii = maxPatronen -1; ii >= 0; ii--) 
		{
			if( ii >= schuss.schussAnzahl)
			{

				patronen[ii].gameObject.SetActive(false);
			
				patronenAnzahl = schuss.schussAnzahl;
			}
		}
	}

	public void neuePatronen()
	{
		for (int i = 0; i < maxPatronen; i++)
		{
			patronen [i].gameObject.SetActive(true);
		}

		patronenAnzahl = schuss.schussAnzahl;
	}

}
