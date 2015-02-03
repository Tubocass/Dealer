using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
public class AStar_Simple : MonoBehaviour {
	//The point to move to
	public Vector3 targetPosition, targetVector;
	public Transform target;
	private Seeker seeker;
	//The calculated path
	public Path path;
	//The AI's speed per second
	public float speed = 100;
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	public void Start () 
	{
		seeker = GetComponent<Seeker>();
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		//seeker.StartPath (transform.position,target.position, OnPathComplete);
	}
	public void OnPathComplete (Path p) 
	{
		//Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	public void setTarget(Transform t)
	{
		this.target = t;
		TrySearchPath ();
	}
	public void setTargetVector(Vector3 t)
	{
		this.targetVector = t;
		TrySearchPath ();
	}
	public void TrySearchPath()
	{
		//lastRepath = Time.time;
		//canSearchAgain = false;
		if (target == null) 
			seeker.StartPath (transform.position, targetVector, OnPathComplete);
		else
		{
			targetPosition = target.position;
			
			seeker.StartPath (transform.position, target.position, OnPathComplete);
		}
	}

	public void FixedUpdate () {
		if (path == null) 
		{
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count) 
		{
			Debug.Log ("End Of Path Reached");
			//seeker.StartPath (transform.position,target.position, OnPathComplete);
			//currentWaypoint = 0;
			path = null;
			return;
			
		}
		//Direction to the next waypoint
		//Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		//dir *= speed * Time.fixedDeltaTime;
		transform.position = Vector2.Lerp(transform.position,path.vectorPath[currentWaypoint], speed * Time.fixedDeltaTime);
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
}
