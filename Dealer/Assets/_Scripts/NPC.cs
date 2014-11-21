using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	Inventory inventory;
	bool clicked;
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () 
	{
		sprite = GetComponent<SpriteRenderer>();
		inventory = GetComponent<Inventory>();
		inventory.AddItem(1);
	}
	void OnGUI()
	{
		Rect trade = new Rect(40,200,100,40);
		Event e = Event.current;
		if(!sprite.bounds.Contains(e.mousePosition)&& !trade.Contains(e.mousePosition)&& e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			clicked = false;
			inventory.showInventory = false;
		}
		if(clicked)
		{
			if(GUI.Button(trade,"Trade"))
			{
				inventory.showInventory = !inventory.showInventory; 
			}
			if(GUI.Button(new Rect(40,240,100,40),"Talk"))
			{
				inventory.showInventory = !inventory.showInventory; 
			}
			if(GUI.Button(new Rect(40,300,100,40),"Quest"))
			{
				inventory.showInventory = !inventory.showInventory; 
			}
		}
	}
	void OnMouseDown() 
	{
		print ("bboobbss");
		clicked = true;
		//inventory.showInventory = true;
		//inventory.AddItem(1);
	}
	void Update()
	{

	}
}
