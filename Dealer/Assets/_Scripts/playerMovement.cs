﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void FixedUpdate() 
	{
		
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		
		//transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rigidbody2D.angularVelocity = 0;
		
		float v = Input.GetAxis ("Vertical");
		rigidbody2D.AddForce (gameObject.transform.up * speed * v);
		float h = Input.GetAxis ("Horizontal");
		rigidbody2D.AddForce (gameObject.transform.right * speed * h);

		//Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		//transform.rotation = rot;
	}
	
}