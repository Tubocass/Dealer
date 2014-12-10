using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewQJ : Inventory
{

	[SerializeField] Transform panel;
	[SerializeField] GameObject imagePrefab;

	protected override void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			//slots.Add(new Quest_Item());
			inventory.Add(new Item());
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(panel);
			
		}
		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		windowRect = new Rect (400, 20, (slotsX*60), (slotsY*60)+20);
		DrawInventory();
		
		
	}
	
	protected virtual void WindowFunction (int windowID) 
	{
		DrawInventory();
		if(showTooltip)
		{
			//GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,100,100),tooltip,skin.GetStyle("box"));
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void Update()
	{
		DrawInventory();
	}
	
	protected override void DrawInventory()
	{
	print ("Words");
		for(int i =0; i<inventory.Count;i++)
		{
			Image icon = GetComponentInChildren<Image>();
			icon.GetComponent<Image>().sprite = inventory[i].itemIcon;
			//icon.transform.SetParent(panel);
		}
	}
	
}
