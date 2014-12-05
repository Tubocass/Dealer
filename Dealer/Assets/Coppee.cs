using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		transform.Translate (0, 0, 10);
	
	}
	
	// Update is called once per frame


		void OnTriggerEnter2D(Collider2D other)
		{
			switch (other.gameObject.tag) {

			case ("Invi"):
			{
				transform.Translate(0,0,1);

				break;
			}
			case ("Invi2"):
			{
				transform.Translate(0,0,-1);

			break;
			}
}
		}
	}
