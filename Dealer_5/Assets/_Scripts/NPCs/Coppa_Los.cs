using UnityEngine;
using System.Collections;

public class Coppa_Los : MonoBehaviour 
{
	Coppa cop;
	Transform tran;
	void Start()
	{
		cop = GetComponentInParent<Coppa>();
		tran = transform;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Vector3 direction = other.transform.position - tran.position;
			float angle = Vector3.Angle(direction, tran.up);
			//Is the object in my field of view?
			if(angle < cop.fieldOfViewAngle*0.5f)
			{
				//are there any obstructions between me and the object?
				RaycastHit2D hit = Physics2D.Raycast(tran.position, direction,cop.length,cop.visionMask);
				if(hit.collider!=null && hit.collider.gameObject.tag == "Player")
				{
					Debug.DrawRay(tran.position, direction, Color.red);
					//Debug.Log("you're a player");
					cop.bPlayerVisible = true;
					cop.lastKnownLoc = hit.transform.position;
				}else{ cop.bPlayerVisible = false;}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			cop.bPlayerVisible = false;
		}
	}
	
}
