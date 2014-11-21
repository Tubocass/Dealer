using UnityEngine;
using System.Collections;

public class Player_Inventory : Inventory 
{
	

	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			showInventory = !showInventory;
		}
	}
	void OnGUI()
	{
		base.OnGUI();
		//if(GUI.Button(new Rect(40,400,100,40),"Save"))
			//SaveInventory();
		//if(GUI.Button(new Rect(40,460,100,40),"Load"))
			//LoadInventory();
	}
	
	void SaveInventory()
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			//PlayerPrefs.SetInt("Inventory"+i,inventory[i].itemID);
		}
	}
	void LoadInventory()
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			//inventory[i] = PlayerPrefs.GetInt("Inventory"+i,-1) >= 0 ? itemDB.items[PlayerPrefs.GetInt("Inventory"+(i-1))] : new Item();
		}
	}
}
