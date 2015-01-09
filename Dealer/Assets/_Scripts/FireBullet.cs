using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public float speed = 6;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
	
		//Vector3 v = rigidbody2D.velocity;
		//v.y = speed;
		//rigidbody2D.velocity = v;
		//transform.position+=Vector3.one;
	}
	void FixedUpdate()
	{
		transform.Translate(direction*speed);
	}
	void OnBecameInvisible() {  
		// Destroy the bullet 
		//Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
