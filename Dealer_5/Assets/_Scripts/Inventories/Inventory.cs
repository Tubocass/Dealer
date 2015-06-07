using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	public int slots, UniqueID, money;
	protected Item_Database itemDB;
	//Inventory tradeInventory;
	public bool bTrading;
	public List<Item> inventory = new List<Item>();
	protected bool showInventory;
	
	public delegate void ItemEvent(Item item);
	public event ItemEvent ItemSold;
	public event ItemEvent ItemAdded;

	protected virtual void Start()
	{	
		for (int i = 0; i<(slots); i++)
		{
			inventory.Add(new Item());
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		if(this.gameObject.tag!="Player")
		{
			UniqueID = (int)(Random.value*1000f);
		}
	}
	public void Trade(string data)
	{


	}
	public void Trade(Inventory tradeInventory, Item item, int value)
	{
		RemoveItem(item);
		AddMoney(value);
		tradeInventory.AddItem(item);
		tradeInventory.AddMoney(-value);
		if(ItemSold!=null)
		{
			ItemSold(item);
		}
	}
	
	public void Trade_Dragged(Item item, int value)
	{
		Inventory tradeInventory = Inventory.Find_Inventory(item.itemOwner);
		AddMoney(-value);
		AddItem(item);
		tradeInventory.AddMoney(value);
		if(tradeInventory.ItemSold!=null)
		{
			tradeInventory.ItemSold(item);
		}
	}
	
	public void AddMoney(int dolla)
	{
		money+=dolla;
	}

	public Item NewItem(string id)
	{
		for (int j = 0; j<itemDB.items.Count; j++) 
		{
			if (itemDB.items [j].itemName == id) 
			{
				return new Item(itemDB.items[j]);
				break;
			}
		}
		return null;
	}
	public Item NewItem(int id)
	{
		for (int j = 0; j<itemDB.items.Count; j++) 
		{
			if (itemDB.items [j].itemID == id) 
			{
				return new Item(itemDB.items[j]);
				break;
			}
		}
		return null;
	}
	public void AddItem(Item item)
	{
		if(item.itemID<1)
			return;
		int s = ContainsItemAt(item.itemID);
		if(s>-1&& inventory[s].bStackable)
		{
			inventory[s].stackAmount += item.stackAmount;
			if(ItemAdded!=null)
			{
				ItemAdded(item);
			}
		}else
		{
			for(int i =0;i<inventory.Count;i++)
			{
				if(inventory[i].itemName == null)
				{
					inventory[i] = new Item(item);
					inventory[i].itemOwner = this.UniqueID;
					if(ItemAdded!=null)
					{
						ItemAdded(item);
					}
					break;
				}
			}
		}
	}
	
	public void AddItem(Item item, int amount)
	{
		AddItem (item.itemName,amount);
	}

	public void AddItem(int id, int amount)
	{
		if(id<1)
			return;
		int s = ContainsItemAt(id);
		if(s>-1&& inventory[s].bStackable)
		{
			inventory[s].stackAmount += amount;
		}else
		{
			for(int a = amount; a>0;a--)
			{
				AddItem(NewItem(id));
			}
		}
	}

	public virtual void AddItem(string id, int amount)
	{
		if(id=="")
			return;
		int s = ContainsItemAt(id);
		if(s>-1&& inventory[s].bStackable)
		{
			inventory[s].stackAmount += amount;
		}else
		{
			for(int a = amount; a>0;a--)
			{
				AddItem(NewItem(id));
			}
		}
	}
	
	public void RemoveItem(Item item)
	{
		RemoveItem (item.itemName);
	}
	public void RemoveItem(string id)
	{
		int k = ContainsItemAt (id);
		if (k > -1) 
		{
			if (inventory[k].bStackable && inventory[k].stackAmount > 1) 
			{
				inventory[k].stackAmount -= 1;
			} else 
			{
				inventory[k] = new Item ();
			}
		}
	}
	public void RemoveItem(Item item, int amount)
	{
		for(int a = amount; a>0;a--)
		{
			RemoveItem(item.itemName);
		}
	}
	public void RemoveItem(string id, int amount)
	{
		for(int a = amount; a>0;a--) 
		{
			RemoveItem (id);
		}
	}
	
	public bool ContainsItem(int id)
	{
		bool result = false;
		for (int i = 0; i<inventory.Count;i++)
		{
			result = inventory[i].itemID == id;
			if(result)
			{
				return result;
				break;
			}
			
		}
		return result;
	}
	
	public virtual bool ContainsItem(string name)
	{
		bool result = false;
		for (int i = 0; i<inventory.Count;i++)
		{
			result = inventory[i].itemName == name;
			if(result)
			{
				return result;
				break;
			}
		}
		return result;
	}
	
	public virtual int ContainsItemAt(int id)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemID == id)
			{
				return i;
				break;
			}
		}
		return -1;
	}
	
	public virtual int ContainsItemAt(string name)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == name)
			{
				return i;
				break;
			}
		}
		return -1;
	}

	public virtual int ReturnItemAmount(int id)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemID == id)
			{
				return inventory[i].stackAmount;
				break;
			}
		}
		return 0;
	}
	
	public virtual int ReturnItemAmount(string id)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == id)
			{
				return inventory[i].stackAmount;
				break;
			}
		}
		return 0;
	}

	public static Inventory Find_Inventory(int id)
	{
		Inventory[] inv = FindObjectsOfType<Inventory>();
		for(int i =0; i<inv.Length;i++)
		{
			if( inv[i].UniqueID == id)
			{ return inv[i];}
		}
		return null;
	}
}
