using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour
{
	public bool bPlayerVisible, bClicked, bPatrolling;
	public float fieldOfViewAngle, length, nextWaypointDistance = 3;
	CircleCollider2D col;
	Transform tran;
	public LayerMask visionMask;
	GameObject player;
	public Vector3 lastKnownLoc;
	AStar_Simple AIPath;
	public GameObject PathGroup;
	[SerializeField] Transform[] aPath;
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	// Use this for initialization
	void Start () 
	{
		col = GetComponentInChildren<CircleCollider2D>();
		length = col.radius*10;
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Inventory>().SoldWeed+=Investigate;
		AIPath = GetComponent<AStar_Simple>();
		if (PathGroup!= null)
		{
			aPath = PathGroup.GetComponentsInChildren<Transform>();
			aPath[0] = tran;
			//AIPath.setTargetVector(aPath[currentWaypoint].position);
		}

	}
	
	public IEnumerator Move(Vector3 dir)
	{
		tran.position = Vector3.MoveTowards(tran.position,dir,.2f);
		Debug.Log("moving");
		yield return new WaitForSeconds(2);
	}

	void Investigate()
	{
		if(bPlayerVisible)
		{
			bPatrolling = false;

			if (Vector2.Distance (tran.position,player.transform.position) < 5)
			{
				Debug.Log("Did you sell drugs in front of me?");
			}else 
			{

				AIPath.setTarget(player.transform);
			}
		}
	}
	void Patrol()
	{
		if (PathGroup!= null)
		{
			if(!bPatrolling)
			{
				bPatrolling = true;
				AIPath.target = null;
				AIPath.setTargetVector(aPath[currentWaypoint].position);
			}
			if (Vector2.Distance (tran.position,aPath[currentWaypoint].position) < nextWaypointDistance)
			{
				currentWaypoint = (currentWaypoint+1) % (aPath.Length);
				AIPath.setTargetVector(aPath[currentWaypoint].position);

			}
		}
	}
	void ChasePlayer()
	{
	}


	void FixedUpdate()
	{
		if(bPlayerVisible)
		{
			
		}else Patrol();
	}
	
}



