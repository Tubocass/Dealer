using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	
	void Start()
	{
		inventory = GetComponent<Inventory>();
		inventory.AddItem(1);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag =="Weed")
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(1);
		}
		
	}
}
