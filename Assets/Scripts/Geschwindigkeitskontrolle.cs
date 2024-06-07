using UnityEngine;
using System.Collections;

public class Geschwindigkeitskontrolle : MonoBehaviour  {

	public float geschwindigkeit;
	private int i;
	private bool unsterblich;

	// Use this for initialization
	void Start () {
		geschwindigkeit = 1;
		unsterblich = false;
	}
	
	// Update is called once per frame
	void Update () {
		i++;
		if (i == 500) {
			geschwindigkeit += 0.05f;
			i = 0;
		}
	
	}

	public void extraGeschw()
	{
		unsterblich = true;
		geschwindigkeit += 3;
	}

	public void extraGeschwEnde()
	{
		unsterblich = false;
		geschwindigkeit -= 3;
	}

	public bool getUnsterblich()
	{
		return unsterblich;
	}

}
