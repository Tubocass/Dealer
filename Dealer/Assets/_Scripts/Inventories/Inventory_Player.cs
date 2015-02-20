using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Inventory_Player : Inventory 
{	/*
	[SerializeField] public RectTransform panel;
	[SerializeField] protected GameObject imagePrefab;
	public List<Image> images = new List<Image>();
	protected override void  Start()
	{
		base.Start();
		for (int i = 0; i<slots; i++)
		{
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(panel);
			
			images.Add(icon.GetComponent<Image>());
			images[i].GetComponent<Dragging>().inv = this;
			icon.SetActive(false);
		}
	}
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			OnClick_Inventory();
		}
	}

	public void OnClick_Inventory()
	{
		showInventory = !showInventory;
		foreach (Image child in images) 
		{
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		}	
	}

	void OnGUI()
	{
		tooltip = "";
		if(showInventory)
		{
			DrawInventory();
		}
	}
	protected virtual void DrawInventory()
	{
		for(int i =0; i<inventory.Count;i++)
		{
			Text text = images[i].GetComponentInChildren<Text>();
			if(text!=null)
			{
				if(inventory[i].itemIcon!=null)
				{
					images[i].sprite = inventory[i].itemIcon;
					
					if(inventory[i].bStackable)
					{
						text.text = ""+inventory[i].stackAmount;
						
					}else text.text = "";
					
				}else{ images[i].sprite = null;text.text = "";}
			}
		}
	}
	void SaveInventory()
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			//PlayerPrefs.SetInt("Inventory"+i,inventory[i].itemID);
		}
	}
	void LoadInventory()
	{
		for(int i = 0;i<inventory.Count;i++)
		{
			//inventory[i] = PlayerPrefs.GetInt("Inventory"+i,-1) >= 0 ? itemDB.items[PlayerPrefs.GetInt("Inventory"+(i-1))] : new Item();
		}
	}
	*/
}
