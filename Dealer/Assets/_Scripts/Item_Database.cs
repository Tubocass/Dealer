using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_Database : MonoBehaviour 
{
	public List<Item> items = new List<Item> ();
	//items.Add(new Item("Weed",1,"Some Reggie",0,0,Item.ItemType.Consumable));
	void Start()
	{
		items.Add(new Item("Weed",1,"Some Reggie",0,0,Item.ItemType.Consumable));
	}
}
