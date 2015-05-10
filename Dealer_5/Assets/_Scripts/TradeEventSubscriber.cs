using UnityEngine;
using System;
using System.Collections;

public class TradeEventSubscriber : MessageHandler
{
	protected Item_Database itemDB;
	Inventory myInventory,tradeInventory;
	public void Start()
	{
		//GameController.instance._currentInventory = 0;
		myInventory = GetComponent<Inventory_NPC>();
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
	}
	public override void HandleMessage( Message message )
	{
		Debug.Log("Message received "+GameController.instance._currentInventory +", "+myInventory.UniqueID);
		string[] meta = message.StringValue.Split(',');
		foreach (string s in meta) 
		{
			s.Trim();
		}
		//("Give" or "Take" in reference to PlayerInventory, ItemName, Amount)

		if (GameController.instance._currentInventory == myInventory.UniqueID) 
		{
			Debug.Log ("You want something from me?");
			int amount =  Int32.Parse(meta[2]);
			tradeInventory = Inventory.Find_Inventory(0);
			if (meta [0] == "Give") 
			{
				int s = tradeInventory.ContainsItemAt(meta[1]);
				if (s>-1)
				{
					Item item = tradeInventory.inventory[s];
					myInventory.AddItem(item, amount);
					tradeInventory.RemoveItem(item, amount);
				}

			}else if (meta [0] == "Take") 
			{
				int s = myInventory.ContainsItemAt(meta[1]);
				if (s>-1)
				{
					Debug.Log ("Here's "+ meta[2]+"Weeds");
					Item item = myInventory.inventory[s];
					myInventory.RemoveItem(item,amount);
					tradeInventory.AddItem(item,amount);
				}
			}
		}

	}

}
