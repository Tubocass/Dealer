using UnityEngine;
using System.Collections;

public class Player_UI : NPC_UI {

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		Inventory = GetComponent<Inventory>();
		window = new Rect(Screen.width - panelUI.rect.width,0,panelUI.rect.width, panelUI.rect.height );
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
