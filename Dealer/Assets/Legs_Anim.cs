using UnityEngine;
using System.Collections;

public class Legs_Anim : MonoBehaviour {

	private Animator anim;

	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");
		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("Walking", true);
		} else 
		{
			anim.SetBool ("Walking", false);
			
		}
	
	}
}
