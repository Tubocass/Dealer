using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	Quest_Journal journal;
	public delegate void TradeAction();
	public static event TradeAction PickedUpWeed;
	//public static event TradeAction SoldWeed;
	
	void Start()
	{
		inventory = GetComponent<Inventory>();
		journal = GetComponent<Quest_Journal>();

		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(2);
		//journal.AddItem(1);
		//journal.AddItem(2);
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
			if(PickedUpWeed!=null)
			PickedUpWeed();
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
		case "Quest":
		{
			//var quest = other.GetComponent<>
			Destroy(other.gameObject,1);
			print ("something");
			journal.AddItem(1);
			break;
		}
		}
		
	}
}
