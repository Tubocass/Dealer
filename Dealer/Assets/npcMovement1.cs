using UnityEngine;
using System.Collections;

public class npcMovement1 : MonoBehaviour {
	private Animator anim;
	public Vector3 startPosition;
	public float speed;
	public static Vector3 movement;
	
	
	void Start () 
	{
		
		startPosition = transform.position;
		anim = gameObject.GetComponent<Animator> ();
	}
	
	
	void FixedUpdate() 
	{
		float lastInputX = transform.position.x;
		float lastInputY  = transform.position.y;
		anim.SetFloat ("Speedx", lastInputX);
		anim.SetFloat ("Speedy", lastInputY);
		
		movement = new Vector3 	(speed * lastInputX, speed * lastInputY, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);
		
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

