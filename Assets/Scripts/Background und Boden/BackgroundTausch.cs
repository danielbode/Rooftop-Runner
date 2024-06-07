using UnityEngine;
using System.Collections;

public class BackgroundTausch : MonoBehaviour {


	public Transform back1;
	public Transform back2;

	public float turnPoint;


	void Update () {

		if (back1.transform.position.x <= turnPoint) {
			back1.transform.position = back2.transform.position - new Vector3(turnPoint,0,0);
		}
		if (back2.transform.position.x <= turnPoint) {
			back2.transform.position = back1.transform.position - new Vector3(turnPoint,0,0); 
		}
	}


}
