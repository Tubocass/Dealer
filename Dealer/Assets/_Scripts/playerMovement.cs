using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	private Animator anim;
	public Vector3 startPosition;
	public Vector2 speed = new Vector2(1, 0);



	void Start () {
		startPosition = transform.position;
		anim = gameObject.GetComponent<Animator> ();
		}

	void Update (){

				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");

				anim.SetFloat ("Speedx", inputX);
				anim.SetFloat ("Speedy", inputY);

				

				Vector3 movement = new Vector3 (
					speed.x * inputX,
					speed.y * inputY,
					0);

				movement *= Time.deltaTime;

				transform.Translate (movement);
		}
	
	// Use this for initialization
	void FixedUpdate() 
	{
				//var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
				//transform.rotation = rot;
				//transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
				//rigidbody2D.angularVelocity = 0;

				float lastInputX = Input.GetAxis ("Horizontal");
				float lastInputY = Input.GetAxis ("Vertical");

				
				

				if (lastInputX != 0 || lastInputY != 0) {
					anim.SetBool ("walking", true);
						if (lastInputX > 0) {
							anim.SetFloat("LastMoveX", 1f);
						} else if (lastInputX < 0) {
							anim.SetFloat("LastMoveX", -1f);
						} else {
							anim.SetFloat ("LastMoveX", 0f); 
						}

						if (lastInputY >0) {
							anim.SetFloat("LastMoveY", 1f);
						} else if (lastInputY < 0 ) {
							anim.SetFloat ("LastMoveY", -1f);
						} else {
							anim.SetFloat("LastMoveY", 0f);
						}

				

				} else {
						anim.SetBool ("walking", false);
				
	}


				//float v = Input.GetAxis ("Vertical");

				//rigidbody2D.AddForce (gameObject.transform.up * speed * v);

				//float h = Input.GetAxis ("Horizontal");
				//rigidbody2D.AddForce (gameObject.transform.right * speed * h);
				//Vector3 newPosition = new Vector3 (h, v, 0) * speed;

				//if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
				//		anim.SetBool ("walking2_0_0", true);
				//		setPlayerDirectionAnim (h, v);
				//} else {
				//		anim.SetBool ("walking2_0_0", false);
			//	}


//	void setPlayerDirectionAnim(float horizInput, float vertInput) {
//		anim.SetFloat ("inputX", horizInput);
//		anim.SetFloat ("inputY", vertInput);
//		anim.SetFloat ("lastmoveX", horizInput);
//		anim.SetFloat ("lastmoveY", vertInput);
//	}
		
		//lastPos = transform.position;
		//Quaternion rot = Quaternion.LookRotation ((transform.position+ newPosition)-transform.position, Vector3.forward);
		//transform.rotation = rot;
		}
}
	
