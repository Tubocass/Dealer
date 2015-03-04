using UnityEngine;
using System.Collections;

public class Coppa : MonoBehaviour
{
	public bool bPlayerVisible, bClicked, bPatrolling, bMoving;
	public float fieldOfViewAngle, length, nextWaypointDistance = 3;
	CircleCollider2D col;
	Transform tran;
	public LayerMask visionMask;
	GameObject player;
	public Vector3 lastKnownLoc;
	AStar_Simple AIPath;
	public Transform PathGroup;
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
			Transform[] points = PathGroup.GetComponentsInChildren<Transform>();
			aPath = new Transform[points.Length-1];
			for(int i = 0;i<points.Length-1;i++)
			{
				aPath[i] = PathGroup.GetChild(i);
			}
			//aPath[0] = tran;
			StartCoroutine("Patrol");
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
				bMoving = true;
			}
		}
	}
	IEnumerator Patrol()
	{
		if (PathGroup!= null)
		{
			while(bPatrolling)
			{
				AIPath.target = null;
				//Debug.Log("I'm Patrolling");
				if(!bMoving)
				{
					AIPath.setTargetVector(aPath[currentWaypoint].position);
					bMoving = true;
					yield return new WaitForSeconds(2);
				}else
				{
					if (Vector2.Distance (tran.position,aPath[currentWaypoint].position) < nextWaypointDistance)
					{
						currentWaypoint = (currentWaypoint+1) % (aPath.Length);
						//Debug.Log("penus");
						yield return new WaitForSeconds(0.5f);
						AIPath.setTargetVector(aPath[currentWaypoint].position);
						bMoving = true;
					}else yield return new WaitForSeconds(1);
				}
				yield return null;
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
			bPatrolling = false;
			bMoving = false;
		}else {
			if(!bMoving)
			StartCoroutine("Patrol");
			bPatrolling = true;
		}
	}
	
}



