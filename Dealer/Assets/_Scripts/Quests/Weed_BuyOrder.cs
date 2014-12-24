using UnityEngine;
using System.Collections;

public class Weed_BuyOrder : Quest 
{

	public int weedAmount,weedDesired, weedBought;


	protected override void Start () 
	{
		base.Start();
		quest1 = new Quest_Item(questDB.items[3]);
		if (journal)
		{
			journal.AddItem(quest1);
		}
		
		if(inv!=null)
		{
			inv.BoughtWeed+=WeedBought;
		}
	
	}

	void Update()
	{
		if(inv!=null)
		{
			weedAmount = inv.ReturnItemAmount("Weed");
		}
	}
	
	void WeedBought()
	{
		if(quest1.bActive)
		{
			weedBought+=1;
			if(weedBought==weedDesired)
			{
				quest1.bAlmostFinished = true;
				quest1.questStage += 1;
			}
			
		}
	}

	public override void FinishQuest()
	{
		player.GetComponent<Inventory>().AddMoney(quest1.questReward);
	}
}

