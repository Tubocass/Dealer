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
	protected bool showInventory, showTooltip;
	protected string tooltip;

	public delegate void TradeAction();
	public event TradeAction SoldWeed;
	public TradeAction BoughtWeed;

	//EventTrigger.Entry entry = new EventTrigger.Entry();
	protected virtual void Start()
	{	
		/* Code for ceating an event
		//This event will respond to a drop event
		entry.eventID = EventTriggerType.PointerClick;
		
		//Create a new trigger to hold our callback methods
		entry.callback = new EventTrigger.TriggerEvent();
		
		//Create a new UnityAction, it contains our DropEventMethod delegate to respond to events
		UnityEngine.Events.UnityAction<BaseEventData> callback =
			new UnityEngine.Events.UnityAction<BaseEventData>(DropEventMethod);
		
		//Add our callback to the listeners
		entry.callback.AddListener(callback);
		//GetComponent<EventTrigger>().delegates.Add(entry);
		
	*/
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

	
	public void Trade(Inventory tradeInventory, Item item, int value)
	{
		RemoveItem(item);
		AddMoney(value);
		ItemSoldEvent(item);
		tradeInventory.AddItem(item);
		tradeInventory.AddMoney(-value);
	}
	public void Trade_Dragged(Item item, int value)
	{
		Inventory tradeInventory = Inventory.Find_Inventory(item.itemOwner);
		AddMoney(-value);
		AddItem(item);
		tradeInventory.AddMoney(value);
		tradeInventory.ItemSoldEvent(item);
	}
	
	public void AddMoney(int dolla)
	{
		money+=dolla;
	}

	public void AddItem(Item item)
	{
		if(item.itemID<1)
			return;
		int s = ContainsItemAt(item.itemID);
		if(s>-1&& inventory[s].bStackable)
		{
			inventory[s].stackAmount += item.stackAmount;
			ItemAddedEvent(item);
			
		}else
		{
			for(int i =0;i<inventory.Count;i++)
			{
				if(inventory[i].itemName == null)
				{
					inventory[i] = new Item(item);
					inventory[i].itemOwner = this.UniqueID;
					ItemAddedEvent(inventory[i]);
					break;
				}
			}
		}
	}
	
	public virtual void AddItem(int id)
	{
		if(id<1)
			return;
		int s = ContainsItemAt(id);
		if(s>-1&& inventory[s].bStackable)
		{
			inventory[s].stackAmount += 1;
			ItemAddedEvent(inventory[s]);
			
		}else
		{
			for(int i =0;i<inventory.Count;i++)
			{
				if(inventory[i].itemName == null)
				{
					for(int j = 0;j<itemDB.items.Count;j++)
					{
						if(itemDB.items[j].itemID==id)
						{
							Item it = new Item(itemDB.items[j]);
							inventory[i] = it;
							inventory[i].itemOwner = this.UniqueID;
							ItemAddedEvent(inventory[i]);
							break;
						}
					}break;
				}
			}
		}
	}

	public void ItemAddedEvent(Item item)
	{
		switch(item.itemName)
		{
		case "Weed":
		{
			if(BoughtWeed!=null)
			{
				BoughtWeed();
			}
			break;
		}
		case "Drank":
		{
			break;
		}
		}
	}
	public void ItemSoldEvent(Item item)
	{
		switch(item.itemName)
		{
		case "Weed":
		{
			if(SoldWeed!=null)
			{
				SoldWeed();
			}
			break;
		}
		case "Drank":
		{
			break;
		}
		}
	}
	public void RemoveItem(Item item)
	{
		if(item.bStackable&&item.stackAmount>1)
		{
			item.stackAmount-=1;
			
		}else
		{
			inventory[ContainsItemAt(item.itemID)]=  new Item();
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
