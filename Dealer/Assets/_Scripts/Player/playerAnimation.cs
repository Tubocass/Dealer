﻿using UnityEngine;
using System.Collections;

public class playerAnimation: MonoBehaviour {
	private Animator anim;
	
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}
			

	void Update() 
	{
		float lastInputX = Input.GetAxisRaw ("Horizontal");
		float lastInputY = Input.GetAxisRaw ("Vertical");

		if (lastInputX != 0 || lastInputY != 0) 
		{
			anim.SetBool ("walking", true);
			if (lastInputX > 0) 
			{
				anim.SetFloat ("LastMoveX", 1f);
			} else if (lastInputX < 0) 
			{
				anim.SetFloat ("LastMoveX", -1f);
			} else 
			{
				anim.SetFloat ("LastMoveX", 0f); 
			}

			if (lastInputY > 0) 
			{
				anim.SetFloat ("LastMoveY", 1f);
			} else if (lastInputY < 0) 
			{
				anim.SetFloat ("LastMoveY", -1f);
			} else 
			{
				anim.SetFloat ("LastMoveY", 0f);
			}

		} else 
		{
			anim.SetBool ("walking", false);
				
		}
	}
}
	
