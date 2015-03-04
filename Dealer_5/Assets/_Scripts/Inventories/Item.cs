using UnityEngine;
using System.Collections;
[System.Serializable]
public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public Texture2D itemTexture;
	public ItemType itemType;
	public int itemOwner;
	public int stackAmount;
	public bool bStackable;
	public int itemValue;

	public enum ItemType
	{
		Weapon, Consumable, Quest
	}
	public Item()
	{
		itemID = -1;
	}
	public Item(string name, int id, string desc, ItemType type, bool stackable, int amount, int value)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemType = type;
		bStackable = stackable;
		stackAmount = amount;
		itemValue = value;
	}
	public Item(Item item)
	{
		itemName = item.itemName;
		itemID = item.itemID;
		itemDesc = item.itemDesc;
		itemType = item.itemType;
		bStackable = item.bStackable;
		stackAmount = item.stackAmount;
		itemIcon = item.itemIcon;
		itemTexture = item.itemTexture;
		itemValue = item.itemValue;
		itemOwner = item.itemOwner;
	}
}
