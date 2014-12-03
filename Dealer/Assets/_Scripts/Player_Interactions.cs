using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	Inventory journal;
	
	void Start()
	{
		inventory = GetComponent<Player_Inventory>();
		journal = GetComponent<Quest_Journal>();
		journal.AddItem(1);
		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(2);
		journal.AddItem(2);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
		
		case "Weed":
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(1);
			break;
		}
		case "Drank":
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(2);
			break;
		}
		case "Pills":
		{
			Destroy(other.gameObject,1);
			print ("something");
			inventory.AddItem(2);
			break;
		}
		}
		
	}
}
