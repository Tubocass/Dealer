using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory_NPC : Inventory 
{
	static Image[] tiles;
	protected override void Start ()
	{
		//panel = GameObject.FindGameObjectWithTag("ImagePrefab").GetComponent<RectTransform>();
		//tiles = panel.GetComponentsInChildren<Image>();

		itemDB = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent <Item_Database> ();
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			inventory.Add(new Item());
			//GameObject icon = (GameObject)Instantiate(imagePrefab);
			//icon.transform.SetParent(panel);
			
			//images.Add(icon.GetComponent<Image>());
			images.Add(panel.GetChild(i).GetComponent<Image>());
			images[i].GetComponent<Dragging>().inv = this;
			//icon.SetActive(false);
		}

	}


}
