using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour 
{
	public bool bPlayerVisible;
	public float fieldOfViewAngle;
	CircleCollider2D col;

	// Use this for initialization
	void Start () 
	{
	
		col = GetComponent<CircleCollider2D>();
	
	}


	void OnTriggerStay2D(Collider2D other)
	{
		Vector3 direction = other.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.up);
		//Is the object in my field of view?
		if(angle < fieldOfViewAngle*0.5f)
		{
			//Debug.Log("you're in my FOV");
			//Debug.DrawRay(transform.position, direction, Color.red);
			//are ther any obstructions between me and the object?
			Vector3 fwd = transform.TransformDirection(Vector3.up*1);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,col.radius);
			if(hit)
			{
				Debug.Log(hit.collider.gameObject.tag);
				Debug.DrawRay(transform.position+fwd, direction-fwd, Color.red);
				//what is the object?
				if(hit.collider.gameObject.tag == "Player")
				{
					Debug.DrawRay(transform.position, direction, Color.red);
					Debug.Log("you're a player");
					bPlayerVisible = true;

				}
			}
		}
	}
}
			

	
