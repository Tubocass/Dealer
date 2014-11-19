﻿using UnityEngine;
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
	private bool draggingItem = false;
	private Item draggedItem;


	void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();

	}

	protected void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		if(showInventory)
		{
			DrawInventory();
			if(showTooltip)
			{
				GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,200,200),tooltip);
			}
		}
		if(draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,50,50),draggedItem.itemIcon);
		}
	
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
				Rect slotRect = new Rect(beginX+(x*60),beginY+(y*60),50,50);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName!=null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
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
			{break;}
			
		}
		return result;
	}
	
	
}