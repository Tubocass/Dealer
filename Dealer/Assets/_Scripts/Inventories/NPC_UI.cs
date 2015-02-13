using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC_UI: MonoBehaviour
{

	[SerializeField] protected RectTransform panelUI, grid;
	protected Inventory inv;
	public Inventory Inventory{get{return inv;}set{inv = value; OnChange_Inventory();}}
	protected bool showInventory, showUI, showQuests;
	List<Image> images = new List<Image>();
	[SerializeField] int slots = 6;
	public Rect window;
	[SerializeField] GameObject imagePrefab;
	// Use this for initialization
	protected virtual void Start () 
	{
		//grid = GameObject.FindGameObjectWithTag("NPC_Grid").GetComponent<RectTransform>();
		/*
		for (int i = 0; i<grid.GetComponentsInChildren<Image>().Length;i++)
		{
			images.Add(grid.GetChild(i).GetComponent<Image>());
			images[i].gameObject.SetActive(false);
		}*/
		window = new Rect(0,0,panelUI.rect.width, panelUI.rect.height );
		for (int i = 0; i<slots; i++)
		{
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(grid);
			
			images.Add(icon.GetComponent<Image>());
			images[i].GetComponent<Dragging>().inv = inv;
			icon.SetActive(false);
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

	public void OnClick_Quests()
	{
		showQuests = !showQuests;
		foreach (Image child in images) 
		{
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		}		
	}

	public void OnChange_Inventory()
	{
		foreach (Image child in images) 
		{
			child.GetComponent<Dragging>().inv = inv;
		}		
	}

	public void ShowUI(bool show)
	{
		showUI = show;
		panelUI.gameObject.SetActive(show);
	}


	protected virtual void OnGUI()
	{
		//tooltip = "";
		if(panelUI!=null && showUI)
		{
			if(inv!=null && showInventory)
			{
				DrawInventory();
			}
			if(inv!=null && showQuests)
			{
				DrawInventory();
			}
		}
	}

	protected virtual void DrawInventory()
	{
		for(int i =0; i<inv.inventory.Count;i++)
		{
			Text text = images[i].GetComponentInChildren<Text>();
			if(text!=null)
			{
				if(inv.inventory[i].itemIcon!=null)
				{
					images[i].sprite = (Sprite)inv.inventory[i].itemIcon;
					
					if(inv.inventory[i].bStackable)
					{
						text.text = ""+inv.inventory[i].stackAmount;
						
					}else text.text = "";
					
				}else{ images[i].sprite = null;text.text = "";}
			}
		}
	}
	void DrawQuests()
	{

	}
}
