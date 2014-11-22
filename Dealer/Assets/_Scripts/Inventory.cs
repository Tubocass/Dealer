using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public float beginX, beginY;
	public GUISkin skin;
	public List<Item> slots = new List<Item> ();
	public List<Item> inventory = new List<Item> ();
	protected Item_Database itemDB;
	string tooltip;
	int prevIndex;
	public bool showInventory = false;
	protected bool showTooltip = false;
	private static bool draggingItem = false;
	public static Item draggedItem;
	public static int draggedAmount;
	private Rect windowRect;
	public int UniqueID;


	void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		windowRect = new Rect (20, 20, (slotsX*60), (slotsY*60)+20);
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();

	}

	protected void OnGUI()
	{
		
		tooltip = "";
		GUI.skin = skin;
		
		if(showInventory)
		{
			windowRect = GUI.Window (UniqueID, windowRect, WindowFunction, "My Inventory");
		}
		if(draggingItem)
		{
			GUI.BringWindowToBack(UniqueID);
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,50,50),draggedItem.itemIcon);
		}
	
	}
	void WindowFunction (int windowID) 
	{
		DrawInventory();
		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,200,200),tooltip);
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void CreateTooltip(Item item)
	{
		tooltip = item.itemName;
	}

	void DrawInventory()
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
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
					if(slots[i].bStackable)
					{
						GUI.Label(slotRect, ""+slots[i].stackAmount,skin.GetStyle("label"));
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
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if(e.type == EventType.mouseUp&& draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if(e.type==EventType.mouseDown&& e.button==1)
						{
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
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
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

	public void AddItem(int id)
	{
		if(ContainsItem(id))
		{
			int s = ContainsItemAt(id);
			if(inventory[s].bStackable)
			{
				inventory[s].stackAmount += 1;
			}
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
							inventory[i]= itemDB.items[j];
							break;
						}
					}break;
				}
			}
		}
	}
	public void RemoveItem(int id)
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			if(inventory[i].itemID==id)
			{
				inventory[i] = new Item();
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
				break;
			}
			
		}
		return result;
	}
	public int ContainsItemAt(int id)
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
	
	
}
