using UnityEngine;
using System.Collections;

public class Legs_Anim : MonoBehaviour {

	private Animator anim;
	Transform tran;
	float degree;

	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		tran = transform;
	}
	// Update is called once per frame
	void Update () 
	{
		float lastInputX = Input.GetAxisRaw ("Horizontal");
		float lastInputY = Input.GetAxisRaw ("Vertical");

		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("Walking", true);
			//Vector3 moveDirection = new Vector3(lastInputX,lastInputY,0);
			//Debug.DrawRay(tran.position, moveDirection, Color.red);
			degree = Mathf.Atan((-lastInputX/lastInputY))*Mathf.Rad2Deg ;
			tran.eulerAngles = new Vector3 (0, 0, degree);
		} else 
		{
			anim.SetBool ("Walking", false);
			
		}
	
	}
}
