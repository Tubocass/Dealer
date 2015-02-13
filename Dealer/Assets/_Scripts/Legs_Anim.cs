using UnityEngine;
using System.Collections;

public class Legs_Anim : MonoBehaviour {

	private Animator anim;
	Transform tran;

	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		tran = transform;
	}
	// Update is called once per frame
	void Update () {
		float lastInputX = Input.GetAxisRaw ("Horizontal");
		float lastInputY = Input.GetAxisRaw ("Vertical");

		Vector3 moveDirection = new Vector3(lastInputX,lastInputY,0);
		Quaternion rot = Quaternion.LookRotation (moveDirection, Vector3.forward);
		tran.rotation = rot;
		tran.eulerAngles = new Vector3 (0, 0, tran.eulerAngles.z);
		rigidbody2D.angularVelocity = 0;

		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("Walking", true);
		} else 
		{
			anim.SetBool ("Walking", false);
			
		}
	
	}
}
