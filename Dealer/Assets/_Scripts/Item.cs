using UnityEngine;
using System.Collections;
[System.Serializable]
public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPower;
	public int itemSpeed;
	public ItemType itemtype;
	public int itemOwner;
	public int stackAmount;
	public bool bStackable;

	public enum ItemType
	{
		Weapon, Consumable, Quest
	}
	public Item()
	{
		itemID = -1;
	}
	public Item(string name, int id, string desc, int power, int speed, ItemType type, bool stackable, int amount)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemPower = power;
		itemSpeed = speed;
		itemtype = type;
		bStackable = stackable;
		stackAmount = amount;
	}
	public Item(Item item)
	{
		itemName = item.itemName;
		itemID = item.itemID;
		itemDesc = item.itemDesc;
		itemPower = item.itemPower;
		itemSpeed = item.itemSpeed;
		itemtype = item.itemtype;
		bStackable = item.bStackable;
		stackAmount = item.stackAmount;
		itemIcon = item.itemIcon;
	}
}
