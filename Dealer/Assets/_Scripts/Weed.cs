using UnityEngine;
using System.Collections;

public class Weed : MonoBehaviour 
{
	public Quest_Item weed;
	void Start()
	{
		weed = new Quest_Item("Weed",2,"Some Dank",Item.ItemType.Consumable,3);
	}
}
