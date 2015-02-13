using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {

	public Inventory inventory;
	public Old_Inventory quests;
	NPC_UI ui;
	bool bClicked;
	SpriteRenderer sprite;
	GameObject player;
	public int health = 99;
	Rect myUI,playerUI;
	public GUISkin skin;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		ui = GameObject.FindGameObjectWithTag("GameController").GetComponent<NPC_UI>();
		sprite = GetComponent<SpriteRenderer>();
		inventory = GetComponent<Inventory_NPC>();
		quests = GetComponent<Quest_Journal>();
		inventory.AddItem(1);
		Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

		myUI = new Rect(0,0,130,200);
		playerUI = new Rect(Screen.width - 130,0, 130, 200 );
	}

	void OnGUI()
	{
		//GUI.Box(playerUI,"",skin.GetStyle("Slot"));
		Event e = Event.current;
		if(!sprite.bounds.Contains(e.mousePosition)&& !playerUI.Contains(e.mousePosition) && !myUI.Contains(e.mousePosition)&& e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			bClicked = false;
			ui.ShowUI(false);
			//inventory.ShowInventory = false;
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
		ui.ShowUI(true);
		ui.Inventory = inventory;
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
