using UnityEngine;
using System.Collections;

public class Player_UI : NPC_UI {

	// Use this for initialization
	protected override void Start () 
	{
		Inventory = GetComponent<Inventory>();
		Journal = GetComponent<Quest_Journal>();
		itemAmount = inv.inventory.Count;
		questAmount = journ.quests.Count;
		base.Start();
	}
	
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			if(showUI&&showInventory)
			ShowUI(false);
			else ShowUI(true);
			OnClick_Inventory();
		}
		if(Input.GetButtonDown("Journal"))
		{
			if(showUI&&showQuests)
				ShowUI(false);
			else ShowUI(true);
			OnClick_Quests();
		}
	}
}
