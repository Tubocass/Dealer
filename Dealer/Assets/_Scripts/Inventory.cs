using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {


	public List<Item> inventory = new List<Item> ();
	private Item_Database itemDB;

	 
	void Awake()
	{
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		print(itemDB.items[0].itemName);
		inventory.Add (itemDB.items[0]);
		inventory.Add (itemDB.items[1]);

	}
	void Start()
	{}

	void OnGUI()
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			GUI.Label(new Rect(10,i*30,800,200),inventory[i].itemName);
		}

	}
}
