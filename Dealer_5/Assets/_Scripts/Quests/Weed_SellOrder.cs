using UnityEngine;
using System.Collections;

public class Weed_SellOrder : Quest 
{
	public int sellAmount,weedSold,weedGathered,gatherAmount;

	void Start()
	{
		base.Start();
		sellAmount= 4; //how much to sell
		gatherAmount = 4;//how much to gather
		finalStage = 2;
		quest1 = new Quest_Item(questDB.items[2]);
		if(inv!=null)
		{
			//inv.SoldWeed+=WeedSold;
			player.GetComponent<Inventory>().ItemAdded+=WeedGathered;
			player.GetComponent<Inventory>().ItemSold+=WeedSold;
			
		}
		if (journal)
		{
			journal.AddItem(quest1);
		}
	
	}
	
	void WeedGathered(Item item)
	{
		if(item.itemName =="Weed")
		{
			if(quest1.bActive)
			{
				weedGathered+=1;	
				if(weedGathered==gatherAmount)
				{
					print ("You gathered all the weed!");
					quest1.questStage+=1;
				}
			}
		}
	}
	
	void WeedSold(Item item)
	{
		if(item.itemName =="Weed")
		{
			if(quest1.bActive)
			{
				weedSold+=1;	
				if(weedSold==sellAmount)
				{
					print ("You sold all the weed!");
					quest1.bAlmostFinished = true;
					quest1.questStage+=1;
				}
			}
		}
	}
	public override void FinishQuest()
	{
		player.GetComponent<Old_Inventory>().AddMoney(quest1.questReward);
	}
}
