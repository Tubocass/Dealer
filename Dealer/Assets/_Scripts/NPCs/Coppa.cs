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
	AStar_Simple AIPath;
	public GameObject PathGroup;
	[SerializeField] Transform[] aPath;
	public float nextWaypointDistance = 3;
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	// Use this for initialization
	void Start () 
	{
		col = GetComponentInChildren<CircleCollider2D>();
		length = col.radius*10;
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Old_Inventory>().SoldWeed+=Investigate;
		AIPath = GetComponent<AStar_Simple>();
		if (PathGroup!= null)
		{
			aPath = PathGroup.GetComponentsInChildren<Transform>();
			aPath[0] = tran;
			AIPath.setTargetVector(aPath[currentWaypoint].position);
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
			Debug.Log("Did you sell drugs in front of me?");
			AIPath.setTarget(player.transform);
		}
	}
	void Patrol()
	{
		if (PathGroup!= null)
		{
			if (Vector2.Distance (tran.position,aPath[currentWaypoint].position) < nextWaypointDistance)
			{
				if(currentWaypoint<aPath.Length-1)
				{
					currentWaypoint++;
					AIPath.setTargetVector(aPath[currentWaypoint].position);
				}else{ currentWaypoint = 1; AIPath.setTargetVector(aPath[currentWaypoint].position);}
			}//else{ AIPath.setTargetVector(aPath[currentWaypoint].position); return;}
		}
	}


	void FixedUpdate()
	{
		if(bPlayerVisible)
		{
			//StartCoroutine("Move",lastKnownLoc);
		}else Patrol();
	}
	
}



