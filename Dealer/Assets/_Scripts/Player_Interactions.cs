using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	
	void Start()
	{
		inventory = GetComponent<Player_Inventory>();
		inventory.AddItem(1);
		inventory.AddItem(2);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag =="Weed")
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(1);
		}
		
		if(other.gameObject.tag =="Drank")
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(2);
		}
		
	}
}
