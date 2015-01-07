using UnityEngine;
using System.Collections;

public class Grow_Weed : MonoBehaviour {
	float timer;
	public float limit;
	public string dick;
	public GameObject prefab;
	bool bBudded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!bBudded)
		{
			timer+=Time.deltaTime;
			if(timer>=limit)
			{
				timer = 0;
				print("boosh"); 
				Instantiate(prefab, transform.position,Quaternion.identity);

			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Weed")
		{
			bBudded = true;
		}
	}
}
