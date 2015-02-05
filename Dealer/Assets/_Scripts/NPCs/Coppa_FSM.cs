using UnityEngine;
using System.Collections;

public class Coppa_FSM : FSMBase {

	public bool bPlayerVisible, bClicked, bPatrolling;
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

	void Start () 
	{
		col = GetComponentInChildren<CircleCollider2D>();
		length = col.radius*10;
		tran = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		//player.GetComponent<Old_Inventory>().SoldWeed+=Investigate;
		AIPath = GetComponent<AStar_Simple>();
		if (PathGroup!= null)
		{
			aPath = PathGroup.GetComponentsInChildren<Transform>();
			aPath[0] = tran;
			AIPath.setTargetVector(aPath[currentWaypoint].position);
		}
		
	}
}
