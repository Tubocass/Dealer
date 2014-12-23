using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	public int slotsX,slotsY;
	[SerializeField] RectTransform panel;
	[SerializeField] GameObject imagePrefab;
	Item_Database itemDB;
	Inventory tradeInventory;
	public bool bTrading;
	public List<Item> inventory = new List<Item>();
	public List<Image> images = new List<Image>();
	public static bool draggingItem = false;
	public static Item draggedItem;
	public static int draggedAmount;
	static int prevIndex;
	public int UniqueID;
	public bool showInventory;
	protected bool showTooltip = false;
	protected string tooltip;
	public int money = 0;

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
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			inventory.Add(new Item());
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(panel);
			
			images.Add(icon.GetComponent<Image>());
			images[i].GetComponent<Dragging>().inv = this;
			icon.SetActive(false);
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();

	}
	
	public void OnClick_Inventory()
	{
		showInventory = !showInventory;
		foreach (Transform child in panel) 
		{
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		}	
	}
	protected virtual void OnGUI()
	{
		tooltip = "";
		if(showInventory)
		DrawInventory();
	}
	
	protected virtual void DrawInventory()
	{
		for(int i =0; i<inventory.Count;i++)
		{
			Text text = images[i].GetComponentInChildren<Text>();
			if(inventory[i].itemIcon!=null)
			{
				images[i].sprite = (Sprite)inventory[i].itemIcon;
				
				if(inventory[i].bStackable)
				{
					if(text!= null)
					text.text = ""+inventory[i].stackAmount;
					
				}else text.text = "";
			
			}
			else{ images[i].sprite = null; text.text = "";}
		}
	}
	
	public void StartTrading(Inventory other)
	{
		tradeInventory = other;
		showInventory = true;
		bTrading = true;
	}

	public void Trade(Item item)
	{
		if(tradeInventory.money>= item.itemValue)
		{
			
			RemoveItem(inventory[ContainsItemAt(item.itemID)]);
			AddMoney(item.itemValue);
			tradeInventory.AddItem(item);
			tradeInventory.AddMoney(-item.itemValue);
			
			if(item.itemName == "Weed")
			{
				//if(SoldWeed!=null)
					//SoldWeed();
			}
		}else return;
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
			inventory[s].stackAmount += 1;
			ItemAddedEvent(item);
			
		}else
		{
			for(int i =0;i<inventory.Count;i++)
			{
				if(inventory[i].itemName == null)
				{
					for(int j = 0;j<itemDB.items.Count;j++)
					{
						if(itemDB.items[j].itemID==item.itemID)
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

	void ItemAddedEvent(Item item)
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
	
}
