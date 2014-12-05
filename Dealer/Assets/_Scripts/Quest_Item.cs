using UnityEngine;
using System.Collections;
[System.Serializable]
public class Quest_Item : Item 
{
	public int questReward;
	public bool bConditionsMet;
	public bool bActive;
	public bool bFinished;
	public int stage = 0;
	public string[] text = new string[1];
	public Quest_Item(){itemID = -1;}
	public Quest_Item(string name, int id, string desc, ItemType type, int reward)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemtype = type;
		questReward = reward;
	}
	public Quest_Item(Quest_Item item)
	{
		itemName = item.itemName;
		itemID = item.itemID;
		itemDesc = item.itemDesc;
		itemtype = item.itemtype;
		itemIcon = item.itemIcon;
	}
	public static string GetText(Quest_Item item)
	{
		if(item.text.Length>0)
		{
			string words = item.text[item.stage];
			if(words != null)
			{
				return words;
			}else return item.itemDesc;
		}else return item.itemDesc;
	}
	public string GetText()
	{
		if(text.Length>0)
		{
			string words = text[stage];
			if(words != null)
			{
				return words;
			}else return itemDesc;
		}else return itemDesc;
	}
}
