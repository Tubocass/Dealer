﻿using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	Inventory inventory;
	Quest_Journal quests;
	bool clicked;
	SpriteRenderer sprite;
	GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		sprite = GetComponent<SpriteRenderer>();
		inventory = GetComponent<Inventory>();
		quests = GetComponent<Quest_Journal>();
		quests.AddItem(1);
		inventory.AddItem(1);
		inventory.AddItem(1);
	}
	void OnGUI()
	{
		Rect trade = new Rect(100,20,110,200);
		Event e = Event.current;
		if(!sprite.bounds.Contains(e.mousePosition)&& !trade.Contains(e.mousePosition)&& e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			clicked = false;
			inventory.showInventory = false;
		}
		if(clicked)
		{
			GUI.BeginGroup(trade);
			if(GUI.Button(new Rect(0,0+5,100,40),"Trade"))
			{
				inventory.StartTrading();
				player.GetComponent<Inventory>().StartTrading();
			}
			if(GUI.Button(new Rect(0,0+55,100,40),"Talk"))
			{
				//inventory.showInventory = !inventory.showInventory; 
			}
			if(GUI.Button(new Rect(0,0+105,100,40),"Quest"))
			{
				quests.showInventory = !quests.showInventory; 
			}
			GUI.EndGroup();
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
