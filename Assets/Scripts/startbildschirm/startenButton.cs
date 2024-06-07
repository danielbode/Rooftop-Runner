using UnityEngine;
using System.Collections;

public class startenButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Starten()
	{
		Application.LoadLevel ("main");
	}
}
