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
	public Quest_Item(string name, int id, string desc, ItemType type, int reward)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemtype = type;
		questReward = reward;
	}
	public Quest_Item(Item item)
	{
		itemName = item.itemName;
		itemID = item.itemID;
		itemDesc = item.itemDesc;
		itemtype = item.itemtype;
		itemIcon = item.itemIcon;
	}

}
