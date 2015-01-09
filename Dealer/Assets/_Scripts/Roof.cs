using UnityEngine;
using System.Collections;

public class Roof : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "Player") {
				gameObject.SetActive(false);
			}
			else {
				
			}
	}
	// Update is called once per frame
	void Update () {
	

	}

}
