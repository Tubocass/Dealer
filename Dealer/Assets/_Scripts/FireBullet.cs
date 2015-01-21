using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public float speed = 6;


	void Start () {
	
	}

	void Update () 
	{
		transform.Translate(Vector3.up*speed*Time.deltaTime);
	}
}
