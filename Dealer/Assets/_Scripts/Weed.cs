using UnityEngine;
using System.Collections;

public class Weed : MonoBehaviour 
{
	public int weedAmount, weedSold;
	public Quest_Item weed1;
	public Quest_Item weed2;
	public Quest_Journal journal;
	Quest_Database questDB;
	public int stage = 0;
	void Start()
	{
		//journal = GetComponent<Quest_Journal>();
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
		weed1 = questDB.items[2];
		weed2 = new Quest_Item("Sell Weed",3,"Sell 3 Dank",Item.ItemType.Quest,3);
		if (journal)
		{
			weed1.bActive = true;
			journal.AddItem(weed1);
			journal.AddItem(weed2);
		}
		//OnEnable();
	}
	void OnEnable()
	{
		Player_Interactions.PickedUpWeed +=IncreaseAmount;
		Inventory.SoldWeed+= WeedSold;
	}
	void OnDisable()
	{
		Player_Interactions.PickedUpWeed -=IncreaseAmount;
		Inventory.SoldWeed-= WeedSold;
	}
	void IncreaseAmount()
	{
		weedAmount+=1;
		if(weedAmount>=3)
		{
			print ("You got all the weed!");
			weed1.stage = 1;
		}
	}
	void WeedSold()
	{
		weedSold+=1;
		if(weedSold>=3)
		{
			print ("You sold all the weed!");
			weed1.bFinished = true;
			stage = 2;
		}
	}
}
