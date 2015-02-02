using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour
{
	public bool bPlayerVisible, bClicked;
	public float fieldOfViewAngle,length;
	CircleCollider2D col;
	Transform tran;
	public LayerMask visionMask;
	GameObject player;
	public Vector3 lastKnownLoc;
	AStar_Simple path;
	
	// Use this for initialization
	void Start () 
	{
		col = GetComponentInChildren<CircleCollider2D>();
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Old_Inventory>().SoldWeed+=Investigate;
		path = GetComponent<AStar_Simple>();
	}
	
	public IEnumerator Move(Vector3 dir)
	{
		tran.position = Vector3.MoveTowards(tran.position,dir,.2f);
		Debug.Log("moving");
		yield return new WaitForSeconds(2);
	}

	void Investigate()
	{
		//if(bPlayerVisible)
		{
			Debug.Log("Did you sell drugs in front of me?");
			path.setTarget(player.transform);
		}
	}


	void FixedUpdate()
	{
		if(bPlayerVisible)
		{
			//StartCoroutine("Move",lastKnownLoc);
		}//else StopCoroutine("Move");
	}
	
}



