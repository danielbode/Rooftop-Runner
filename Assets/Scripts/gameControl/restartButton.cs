using UnityEngine;
using System.Collections;



public class restartButton : MonoBehaviour {

	void Start()
	{
	}

	public void restarten()
	{
		Application.LoadLevel (Application.loadedLevel);

	}


}
