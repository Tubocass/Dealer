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

		//window = new Rect(Screen.width - panelUI.rect.width,0,panelUI.rect.width, panelUI.rect.height );
		journ.AddItem(1);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			ShowUI(!showUI);
			OnClick_Inventory();
		}
	}
}
