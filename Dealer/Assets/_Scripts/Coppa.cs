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
	public Vector3 lastKnownLoc;

	// Use this for initialization
	void Start () 
	{
		col = GetComponentInChildren<CircleCollider2D>();
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public IEnumerator Move(Vector3 dir)
	{
		tran.position = Vector3.MoveTowards(tran.position,dir,.2f);
		Debug.Log("moving");
		yield return new WaitForSeconds(2);
	}
	void FixedUpdate()
	{
		if(bPlayerVisible)
		{
			StartCoroutine("Move",lastKnownLoc);
		}else StopCoroutine("Move");
	}

}
			

	
