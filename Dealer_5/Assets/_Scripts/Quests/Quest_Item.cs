using UnityEngine;
using System.Collections;
[System.Serializable]
public class Quest_Item : Item 
{
	public int questReward,questStage = 0;
	public bool bPreConditionsMet,bActive,bAlmostFinished,bFinished;
	public string[] text = new string[1];
	public DialogQuestion question1;

	public Quest_Item(){itemID = -1;}
	public Quest_Item(string name, int id, string desc, ItemType type, int reward)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemType = type;
		questReward = reward;
	}
	public Quest_Item(Quest_Item item)
	{
		itemName = item.itemName;
		itemID = item.itemID;
		itemDesc = item.itemDesc;
		itemType = item.itemType;
		itemIcon = item.itemIcon;
		questReward = item.questReward;
		questStage = item.questStage;
		text = item.text;
	}
	
	public void FinishQuest()
	{
		bFinished = true;
		bAlmostFinished = false;
		bActive = false;
		bPreConditionsMet = false;
	}
	public static string GetText(Quest_Item item)
	{
		if(!item.bFinished)
		{
			if(item.text.Length>0)
			{
				string words = item.text[item.questStage];
				if(words != null)
				{
					return words;
				}
			}
		}
		return item.itemDesc;
	}
	public string GetText()
	{
		if(!bFinished)
		{
			if(text.Length>0)
			{
				string words = text[questStage];
				if(words != null)
				{
					return words;
				}
			}
		}
		return itemDesc;
	}
}
