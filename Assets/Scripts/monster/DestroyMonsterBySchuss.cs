using UnityEngine;
using System.Collections;

public class DestroyMonsterBySchuss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "monster")    //schuss zerstört monster und sich selbst wenn er auf ein Monster trifft. gleicher code auch bei onCollisionEnter2d 
		{								// weil monster aus 2 collidern bestehen (einer normaler Collider der andere Trigger)
			Destroy (this.gameObject);
			Destroy (other.gameObject);

			
		}

		if (other.tag == "hindernis") { // löscht schuss wenn er auf hindernis trifft damit er nicht durchfliegen kann
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "monster") {
			Destroy (this.gameObject);
			Destroy (other.gameObject);
						
		}
	}
}
