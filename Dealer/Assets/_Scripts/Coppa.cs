using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour 
{
	public bool bPlayerVisible;
	public float fieldOfViewAngle,length;
	CircleCollider2D col;
	Transform tran;
	public LayerMask visionMask;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		col = GetComponent<CircleCollider2D>();
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
	}


	IEnumerator Move(Vector3 dir)
	{
		tran.position = Vector3.MoveTowards(tran.position,dir,.2f);
		Debug.Log("moving");
		yield return null;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Vector3 direction = other.transform.position - tran.position;
			float angle = Vector3.Angle(direction, tran.up);
			//Is the object in my field of view?
			if(angle < fieldOfViewAngle*0.5f)
			{
				//are there any obstructions between me and the object?
				//Vector3 fwd = tran.TransformDirection(Vector3.up*1);
				RaycastHit2D hit = Physics2D.Raycast(tran.position, direction,length,visionMask);
				if(hit.collider!=null && hit.collider.gameObject.tag == "Player")
				{
					Debug.DrawRay(tran.position, direction, Color.red);
					//Debug.Log("you're a player");
					bPlayerVisible = true;
					StartCoroutine("Move",(player.transform.position));
				}else{ bPlayerVisible = false; StopCoroutine("Move");}
			}
		}
	}
		
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			bPlayerVisible = false;
		}
	}
}
			

	
