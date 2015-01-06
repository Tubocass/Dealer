using UnityEngine;
using System.Collections;

public class Inventory_NPC : Old_Inventory {

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		AddItem(4);
		
	}

}
