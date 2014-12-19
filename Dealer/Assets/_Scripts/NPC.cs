using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {

	Inventory inventory;
	Quest_Journal quests;
	bool clicked;
	SpriteRenderer sprite;
	GameObject player;
	public GUI Trade_Button;
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
		/*if(clicked)
		{
			GUI.BeginGroup(trade);
			if(GUI.Button(new Rect(0,0+5,100,40),"Trade"))
			{
				Inventory playerInventory = player.GetComponent<Inventory>();
				inventory.StartTrading(playerInventory);
				//inventory.showInventory = !inventory.showInventory; 
				playerInventory.StartTrading(inventory);
			}
			if(GUI.Button(new Rect(0,0+55,100,40),"Talk"))
			{
				//GUI.Box(new Rect(10,20,100,100),new GUIContent(words));
				//inventory.showInventory = !inventory.showInventory; 
			}
			if(GUI.Button(new Rect(0,0+105,100,40),"Quest"))
			{
				quests.showInventory = !quests.showInventory; 
			}
			GUI.EndGroup();
		}else{quests.showInventory = false;}
		*/
	}
	public void OnMouseDown() 
	{
		print ("bboobbss");
		clicked = true;
		inventory.showInventory = true;
		//inventory.AddItem(1);
	}
	
	public void OnClick_Trade()
	{
		Inventory playerInventory = player.GetComponent<Inventory>();
		inventory.StartTrading(playerInventory);
		//inventory.showInventory = !inventory.showInventory; 
		playerInventory.StartTrading(inventory);
	}
	public void OnClick_Quests()
	{
		quests.showInventory = !quests.showInventory; 
	}
	void Update()
	{

	}
	
	/*void OnGUI()
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
				Inventory playerInventory = player.GetComponent<Inventory>();
				inventory.StartTrading(playerInventory);
				//inventory.showInventory = !inventory.showInventory; 
				playerInventory.StartTrading(inventory);
			}
			if(GUI.Button(new Rect(0,0+55,100,40),"Talk"))
			{
				//GUI.Box(new Rect(10,20,100,100),new GUIContent(words));
				//inventory.showInventory = !inventory.showInventory; 
			}
			if(GUI.Button(new Rect(0,0+105,100,40),"Quest"))
			{
				quests.showInventory = !quests.showInventory; 
			}
			GUI.EndGroup();
		}else{quests.showInventory = false;}
	}*/
}
