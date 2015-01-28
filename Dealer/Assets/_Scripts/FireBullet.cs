using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public float speed = 6;
	Transform tran;


	void Start () 
	{
		tran = transform;
		Destroy(this.gameObject,5);
	}

	void Update () 
	{
		//tran.Translate(Vector3.up*speed*Time.deltaTime);
		Vector3 targetDir  = tran.position + tran.up; 

		tran.position = Vector3.MoveTowards(tran.position,targetDir,0.25f);

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("bull it");
		Destroy(this.gameObject);
	}

}
