using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewQJ : MonoBehaviour
{
	public int slotsX,slotsY;
	[SerializeField] Transform panel;
	[SerializeField] GameObject imagePrefab;
	public List<Item> inventory = new List<Item>();
	public List<Image> images = new List<Image>();
	protected static bool draggingItem = false;
	public static Item draggedItem;
	public static int draggedAmount;
	Item_Database itemDB;
	public Sprite theSprite;
	public int UniqueID;
	public bool bTrading;
	public int money = 0;
	Inventory tradeInventory;

	public delegate void TradeAction();
	public event TradeAction SoldWeed;
	public TradeAction BoughtWeed;


	protected void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			//slots.Add(new Quest_Item());
			inventory.Add(new Item());
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(panel);
			icon.SetActive(false);
			images.Add(icon.GetComponent<Image>());
			
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		//windowRect = new Rect (400, 20, (slotsX*60), (slotsY*60)+20);
		//DrawInventory();
		
		
	}


	void Update()
	{
		//DrawInventory();
	}
	
	public void DrawInventory()
	{
		print ("Words");
		 
		foreach (Transform child in panel) {
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		}
		//image = panel.GetComponentsInChildren<Image>();
		//foreach(Image i in image){i.gameObject.SetActive(true);}
		for(int i =0; i<inventory.Count;i++)
		{
			//Image image = GetComponentInChildren<Image>();
			if(inventory[i].itemIcon!=null)
			{
				print (i);
				print (inventory[i].itemIcon.ToString());
				//images[i].color = Color.blue;
				images[i].sprite = (Sprite)inventory[i].itemIcon;
			}
		}
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

	public virtual void AddItem(int id)
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
							//inventory[i].itemOwner = this.UniqueID;
							//ItemAddedEvent(inventory[i]);
							break;
						}
					}break;
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
