using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	Inventory inventory;
	// Use this for initialization
	void Start () 
	{
		inventory = GetComponent<Inventory>();
		inventory.AddItem(1);
	}
	
	void OnMouseDown() 
	{
		print ("bboobbss");
		inventory.showInventory = true;
		inventory.AddItem(1);
	}
}
