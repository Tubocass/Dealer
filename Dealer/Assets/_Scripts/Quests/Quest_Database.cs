using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest_Database : MonoBehaviour{

	public List<Quest_Item> items = new List<Quest_Item> ();

	public void Awake()
	{
		//items[3] = new Quest_Item("Sell Weed",2,"Sell 3 Dank",Item.ItemType.Quest,3);
	}
}
