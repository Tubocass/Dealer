using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 6;
	// Use this for initialization
	void Start () {
	
		Vector3 v = rigidbody2D.velocity;
		v.y = speed;
		rigidbody2D.velocity = v;
	}
	void OnBecameInvisible() {  
		// Destroy the bullet 
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
