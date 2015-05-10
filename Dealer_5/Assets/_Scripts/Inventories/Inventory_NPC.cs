using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory_NPC : Inventory 
{

	protected override void Start ()
	{
		base.Start ();
		AddItem ("Weed", 3);
	}


}
