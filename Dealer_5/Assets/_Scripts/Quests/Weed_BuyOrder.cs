using UnityEngine;
using System.Collections;

public class Weed_BuyOrder : Quest 
{

	public int weedAmount,weedDesired, weedBought;
	public DialogQuestion question1;
	Inventory playerInventory;

	protected override void Start () 
	{
		base.Start();
		playerInventory = player.GetComponent<Inventory>();
		
		question1.question = "Do you you have any Good?";
		question1.answers.Add(new DialogAnswer("I Can Sell You Some Pot",DialogAnswer.AnswerType.Agree));
		question1.answers[0].precondition = playerInventory.ContainsItem("Weed");
		question1.answers.Add(new DialogAnswer("I'm all out of Bud, bud.",DialogAnswer.AnswerType.Disagree));
		finalStage = 1;
		weedDesired = 3;
		quest1 = new Quest_Item(questDB.items[3]);
		if (journal)
		{
			journal.AddItem(quest1);
		}
		
		if(inv!=null)
		{
			inv.ItemAdded+=WeedBought;
		}
	}

	public void SelectAnswer(DialogAnswer answer)
	{
		if(answer.type == DialogAnswer.AnswerType.Agree)
		{
			playerInventory.Trade(inv,playerInventory.inventory[playerInventory.ContainsItemAt(1)],5);
		}
		if(answer.type == DialogAnswer.AnswerType.Disagree)
		{
			
		}
	}
	void Update()
	{
		if(inv!=null)
		{
			weedAmount = inv.ReturnItemAmount("Weed");
		}
	}
	
	void WeedBought(Item item)
	{
		if (item.itemName == "Weed")
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
	}

	public override void FinishQuest()
	{
		player.GetComponent<Inventory>().AddMoney(quest1.questReward);
	}
}

