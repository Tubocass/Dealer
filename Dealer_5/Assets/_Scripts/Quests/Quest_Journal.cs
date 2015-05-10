using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest_Journal : Inventory {
	string words;
	int selectedQuest;
	public Vector2 scrollPosition = Vector2.zero;
	Quest_Database questDB;
	public List<Quest_Item> quests = new List<Quest_Item>();

	
	protected override void Start()
	{
		for (int i = 0; i<(slots); i++)
		{
			//slots.Add(new Quest_Item());
			quests.Add(new Quest_Item());
		}
		if(this.gameObject.tag!="Player")
		{
			UniqueID = (int)(Random.value*2000f);
		}
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
	}
	
	public override int ContainsItemAt(int id)
	{
		for (int i = 0; i<quests.Count;i++)
		{
			if(quests[i].itemID == id)
			{
				return i;
				break;
			}
			
		}
		return -1;
	}

	public void AddItem(Quest_Item item)
	{
		int s = ContainsItemAt(item.itemID);
		if(item.itemID<1||s>-1)
		{
			return;
			
		}else
		{
			for(int i =0;i<quests.Count;i++)
			{
				if(quests[i].itemName == null)
				{
					quests[i] = item;
					quests[i].itemOwner = this.UniqueID;
					break;
				}
			}
		}
	}

	public  void AddItem(int id)
	{
		int s = ContainsItemAt(id);
		if(id<1||s>-1)
		{
			return;
			
		}else
		{
			for(int i =0;i<quests.Count;i++)
			{
				if(quests[i].itemName == null)
				{
					for(int j = 0;j<questDB.items.Count;j++)
					{
						if(questDB.items[j].itemID==id)
						{
							Quest_Item it = new Quest_Item(questDB.items[j]);
							quests[i] = it;
							quests[i].itemOwner = this.UniqueID;
							break;
						}
					}break;
				}
			}
		}
	}

	public static Quest_Journal Find_Journal(int id)
	{
		Quest_Journal[] inv = FindObjectsOfType<Quest_Journal>();
		for(int i =0; i<inv.Length;i++)
		{
			if( inv[i].UniqueID == id)
			{ return inv[i];}
		}
		return null;
	}
}
