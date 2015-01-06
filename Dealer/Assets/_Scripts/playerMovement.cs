using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	
	public float speed;
	Vector3 lastPos;
	
	// Use this for initialization
	void FixedUpdate() 
	{
			
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		
		//transform.rotation = rot;
		//transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		//rigidbody2D.angularVelocity = 0;
		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3(h,v,0);
		Vector3 newPosition = movement*speed*Time.fixedDeltaTime;
		transform.Translate(newPosition);
	
		lastPos = transform.position;
		//Quaternion rot = Quaternion.LookRotation ((transform.position+ newPosition)-transform.position, Vector3.forward);
		//transform.rotation = rot;
	}
	
}