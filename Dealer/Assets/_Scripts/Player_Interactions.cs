using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	Quest_Journal journal;
	public Quest q1;
	public delegate void TradeAction();
	public static event TradeAction PickedUpWeed;
	
	void Start()
	{
		inventory = GetComponent<Player_Inventory>();
		journal = GetComponent<Quest_Journal>();
		//Quest newQ = (Quest)Quest.CreateInstance("Quest");
		//newQ = q1;
		//q1.setQuest("Collection",1,"Collect 5 whole marijuana",Quest.QuestType.Trade,5);

		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(2);
		if(q1)
		journal.AddItem(q1);
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
