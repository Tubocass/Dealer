using UnityEngine;
using System.Collections;

public class npcMovement : MonoBehaviour {

	Transform target; //the enemy's target
	int moveSpeed = 3; //move speed
	int rotationSpeed = 3; //speed of turning
	float range =10f;
	float range2 =10f;
	float stop =0;
	Transform myTransform; //current transform data of this enemy
	public void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}
	
	public void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
		
	}
	
	public void Update () {
		//rotate to look at the player
		var distance = Vector3.Distance(myTransform.position, target.position);
		if (distance<=range2 &&  distance>=range){
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
		
		
		else if(distance<=range && distance>stop){
			
			//move towards the player
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		else if (distance<=stop) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
		
		
	}
}