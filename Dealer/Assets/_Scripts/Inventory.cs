using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> slots = new List<Item> ();
	public List<Item> inventory = new List<Item> ();
	private Item_Database itemDB;
	string tooltip;
	private bool showInventory = false;
	private bool showTooltip = false;


	void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();

	}
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			showInventory = !showInventory;
		}
	}
	void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		if(showInventory)
		{
			DrawInventory();
		}
		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x+20f,Event.current.mousePosition.y+20f,200,200),tooltip);
		}
	}
	void CreateTooltip(Item item)
	{
		tooltip = item.itemName;
	}

	void DrawInventory()
	{
		int i = 0;
		for (int y=0;y<slotsY;y++)
		{
			for (int x=0;x<slotsX;x++)
			{
				Rect slotRect = new Rect(x*60,y*60,50,50);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName!=null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
					if(slotRect.Contains(Event.current.mousePosition))
					{
						CreateTooltip(slots[i]);
						showTooltip = true;
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

	void AddItem(int id)
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
					}
				}
			}
		}
	}
	void RemoveItem(int id)
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

	bool ContainsItem(int id)
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
