using UnityEngine;
using System.Collections;

public class WeedQuest : MonoBehaviour 
{
	public int weedAmount,weedGathered, weedSold;
	public Quest_Item weed1;
	public Quest_Journal questGiver;
	Quest_Database questDB;
	Inventory inv;
	public GameObject player;
	public int stage = 0;
	void Start()
	{
		//journal = GetComponent<Quest_Journal>();
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
		weed1 = new Quest_Item(questDB.items[2]);
		player = GameObject.FindGameObjectWithTag("Player");
		inv = GetComponent<Inventory>();
		if(inv!=null)
		{
			weedAmount = 0;
		}
		questGiver = GetComponent<Quest_Journal>();
		if (questGiver)
		{
			questGiver.AddItem(weed1);
		}
		//OnEnable();
	}
	void OnEnable()
	{
		Player_Interactions.PickedUpWeed +=IncreaseAmount;
		Inventory.SoldWeed+= WeedSold;
		Quest_Journal.TalkTo+= TalkToQuestGiver;
	}
	void OnDisable()
	{
		Player_Interactions.PickedUpWeed -=IncreaseAmount;
		Inventory.SoldWeed-= WeedSold;
	}
	void IncreaseAmount()
	{
		if(weed1.bActive)
		{
			weedGathered+=1;
			if(weedGathered>=3)
			{
				print ("You got all the weed!");
				weed1.questStage = 1;
				stage = 1;
					
			}
		}
	}
	void WeedSold()
	{
		if(weed1.bActive)
		{
			int newAmount = GetComponent<Inventory>().ReturnItem("Weed").stackAmount;
			if(newAmount>weedAmount)
			{
				weedAmount = newAmount;
				weedSold+=1;
				if(weedSold>=3)
				{
					print ("You sold all the weed!");
					weed1.bAlmostFinished = true;
					weed1.questStage = 2;
					stage = 2;
				}
			}
		}
	}
	void TalkToQuestGiver()
	{
		if(weed1.bActive)
		{
			if(weed1.questStage == 2)
			{
				player.GetComponent<Inventory>().AddMoney(weed1.questReward);
				weed1.FinishQuest();
			}
		}
		
	}
}
