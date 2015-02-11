using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {

	public Inventory inventory;
	public Old_Inventory quests;
	bool bClicked;
	SpriteRenderer sprite;
	GameObject player;
	public static int selectedID;
	public GUI Trade_Button;
	public int health = 99;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		sprite = GetComponent<SpriteRenderer>();
		//if(GetComponent<Inventory_NPC>()!=null)
		{
			inventory = GetComponent<Inventory_NPC>();
		}
		//else inventory = GetComponent<Old_Inventory>();
		quests = GetComponent<Quest_Journal>();
		
	}

	void OnGUI()
	{
		Rect trade = new Rect(100,20,110,200);
		Event e = Event.current;
		if(!sprite.bounds.Contains(e.mousePosition)&& !trade.Contains(e.mousePosition)&& e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			bClicked = false;
			//inventory.showInventory = false;
		}
		/*if(bClicked&& Vector3.Distance(transform.position, player.transform.position)<=15)
		{
			GUI.BeginGroup(trade);
			if(GUI.Button(new Rect(0,0+5,100,40),"Trade"))
			{
				inventory.showInventory = !inventory.showInventory; 
				Old_Inventory playerInventory = player.GetComponent<Old_Inventory>();
				inventory.StartTrading(playerInventory);
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
		}else{quests.showInventory = false; inventory.showInventory = false; bClicked = false;}
*/
	}
	public void OnMouseDown() 
	{
		print ("bboobbss");
		bClicked = true;
		selectedID = inventory.UniqueID;
		//inventory.showInventory = true;
		//inventory.AddItem(1);
	}
	
	public void OnClick_Trade()
	{
		//Inventory.Find_Inventory(selectedID).showInventory = !Inventory.Find_Inventory(selectedID).showInventory;
		//inventory.showInventory = true;
		inventory.OnClick_Inventory();

	}
	public void OnClick_Quests()
	{
		quests.showInventory = !quests.showInventory; 
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
