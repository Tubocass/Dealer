using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {

	public Inventory inventory;
	public Quest_Journal quests;
	NPC_UI ui, playerUI;
	bool bClicked;
	SpriteRenderer sprite;
	GameObject player;
	public int health = 99;

	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		ui = GameObject.FindGameObjectWithTag("GameController").GetComponent<NPC_UI>();
		sprite = GetComponent<SpriteRenderer>();
		inventory = GetComponent<Inventory_NPC>();
		quests = GetComponent<Quest_Journal>();
		playerUI = player.GetComponent<Player_UI>();
	}

	void OnGUI()
	{
		Event e = Event.current;
		//GUI.Box(ui.window,"MY UI ");
		//GUI.Box(playerUI.window,"P UI ");
		if(!sprite.bounds.Contains(e.mousePosition)&& !playerUI.Window.Contains(e.mousePosition) 
		   && !ui.Window.Contains(e.mousePosition) && e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			bClicked = false;
			ui.ShowUI(false);
		}
	}
	public void OnMouseDown() 
	{
		print ("bboobbss");
		bClicked = true;
		ui.Journal = quests;
		ui.Inventory = inventory;
		ui.ShowUI(true);
	}
}
