using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Old_Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public float beginX, beginY;
	public GUISkin skin;
	public List<Item> slots = new List<Item> ();
	public List<Item> inventory = new List<Item> ();
	protected Item_Database itemDB;
	protected string tooltip;
	static int prevIndex;
	public bool showInventory = false;
	protected bool showTooltip = false;
	protected static bool draggingItem = false;
	public static Item draggedItem;
	public static int draggedAmount;
	protected Rect windowRect;
	public int UniqueID;
	public bool bTrading;
	public float money = 0;
	Old_Inventory tradeInventory;
	
	public delegate void TradeAction();
	public event TradeAction SoldWeed;
	public TradeAction BoughtWeed;
	
	
	protected virtual void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		windowRect = new Rect (20, 20, (slotsX*60), (slotsY*60)+20);
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		if(this.gameObject.tag!="Player")
		{
			UniqueID = (int)(Random.value*1000f);
		}
	}
	
	protected virtual void OnGUI()
	{
		
		tooltip = "";
		GUI.skin = skin;
		
		if(showInventory)
		{
			windowRect = GUI.Window (UniqueID, windowRect, WindowFunction,money.ToString(),skin.GetStyle("Window"));
		}
		if(draggingItem)
		{
			//GUI.BringWindowToBack(UniqueID);
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,50,50),draggedItem.itemTexture);
		}
		
	}
	protected virtual void WindowFunction (int windowID) 
	{
		DrawInventory();
		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,100,100),tooltip,skin.GetStyle("box"));
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	protected void CreateTooltip(Item item)
	{
		tooltip = item.itemName+"\n Worth: "+item.itemValue;
	}
	
	protected virtual void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for (int y=0;y<slotsY;y++)
		{
			for (int x=0;x<slotsX;x++)
			{
				Rect slotRect = new Rect(5+(x*60),20+(y*60),50,50);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName!=null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemTexture);
					if(slots[i].bStackable)
					{
						GUI.Label(slotRect, ""+slots[i].stackAmount,skin.GetStyle("label"));
					}
					if(bTrading)
					{
						if(slotRect.Contains(e.mousePosition))
						{
							if(e.type==EventType.mouseDown&& e.button==1)
							{
								
							}
						}
					}
					if(slotRect.Contains(e.mousePosition))
					{
						if(!draggingItem)
						{
							CreateTooltip(slots[i]);
							showTooltip = true;
						}
						if(e.button==0 && e.type==EventType.mouseDrag && !draggingItem)
						{
							//print (UniqueID);
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if(e.type==EventType.mouseUp&& draggingItem)
						{
							if(draggedItem.itemOwner != UniqueID)
							{
								return;
								
							}else{
								inventory[prevIndex] = inventory[i];
								inventory[i] = draggedItem;
								draggingItem = false;
								draggedItem = null;
							}
						}
						if(e.type==EventType.mouseDown&& e.button==1)
						{
							if(bTrading)
							{
								Trade(inventory[i]);
							}
							
							if(slots[i].itemtype==Item.ItemType.Consumable)
							{
								print ("balls");
							}
						}
					}
				}else{
					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp&& draggingItem)
						{
							print (draggedItem.itemOwner);
							
							if(draggedItem.itemOwner != UniqueID)
							{
								if(bTrading)
								{
									if(money>= draggedItem.itemValue*draggedItem.stackAmount)
									{
										
										AddMoney(-draggedItem.itemValue*draggedItem.stackAmount);
										inventory[i] = draggedItem;
										inventory[i].itemOwner = UniqueID;
										tradeInventory.AddMoney(draggedItem.itemValue*draggedItem.stackAmount);
										
										ItemAddedEvent(draggedItem);
										draggingItem = false;
										draggedItem = null;
									}
								}
								
								
							}else{
								inventory[i] = draggedItem;
								draggingItem = false;
								draggedItem = null;
							}
							
						}
					}
				}
				if (tooltip == "")
				{
					showTooltip = false;
				}
				
				i++;
			}
		}
	}
	
	public void StartTrading(Old_Inventory other)
	{
		tradeInventory = other;
		//showInventory = true;
		bTrading = true;
	}
	public void Trade(Item item)
	{
		if(tradeInventory.money>= item.itemValue)
		{
			
			RemoveItem(inventory[ContainsItemAt(item.itemID)]);
			AddMoney(item.itemValue);
			tradeInventory.AddItem(item);
			tradeInventory.money -= item.itemValue;
			
			if(item.itemName == "Weed")
			{
				if(SoldWeed!=null)
					SoldWeed();

			}
		}else return;
	}
	public void AddMoney(int dolla)
	{
		money+=dolla;
	}
	
	public void AddItem(Item item)
	{
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
	
	public virtual Item ReturnItem(string name)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == name)
			{
				return inventory[i];
				break;
			}	
		}
		return null;
	}
	public virtual int ReturnItemAmount(string name)
	{
		for (int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == name)
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
