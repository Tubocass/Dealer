using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

public class NPC_UI: MonoBehaviour
{
	[SerializeField] protected RectTransform panelUI, inventoryPanel, inventoryGrid;
	protected Inventory inv;//set by clicking on an NPC
	public Inventory Inventory{get{return inv;}set{inv = value;}}
	protected bool showInventory, showUI;
	protected List<Image> invImages = new List<Image>();
	[SerializeField] protected int itemAmount = 6;
	protected Rect window;
	public Rect Window{get{return window;}}
	[SerializeField] protected GameObject imagePrefab, buttonPrefab;
	[SerializeField] protected EventSystem events;
	public MarketManager manager;
	[SerializeField] Sprite defaultSprite;
	StringEvent action;

	protected virtual void Start () 
	{
		window = GetScreenRect((RectTransform)panelUI.transform);
		inventoryPanel.GetComponent<Inventory_Background>().ui = this;
		manager = GameObject.FindGameObjectWithTag("MarketManager").GetComponent<MarketManager>();
		for (int i = 0; i<itemAmount; i++)
		{
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(inventoryGrid);
			
			invImages.Add(icon.GetComponent<Image>());
			invImages[i].GetComponent<Dragging>().ui = this;
			invImages[i].GetComponent<RightClickSell>().ui = this;
			//invSlots[i].GetComponent<Dragging>().inv = inv;
			icon.SetActive(true);
		}
	}
	
	public virtual void OnClick_Inventory()
	{
		inventoryPanel.gameObject.SetActive (!inventoryPanel.gameObject.activeSelf);
		showInventory = !showInventory;
	}
	
	public void ShowUI(bool show)
	{
		showUI = show;
		//showDialogue = true;
		panelUI.gameObject.SetActive(show);
	}
	
	protected virtual void OnGUI()
	{
		//tooltip = "";
		window = GetScreenRect((RectTransform)panelUI.transform);
		window.y = 0;
		
		if(panelUI!=null && showUI)
		{
			if(inv!=null && showInventory)
			{
				DrawInventory();
			}
		}
	}

	protected virtual void DrawInventory()
	{
		for(int i =0; i<inv.inventory.Count;i++)
		{
			Text text = invImages[i].GetComponentInChildren<Text>();
	
			if(text!=null)
			{
				if(inv.inventory[i].itemIcon!=null)
				{
					invImages[i].sprite = inv.inventory[i].itemIcon;
					
					if(inv.inventory[i].bStackable)
					{
						text.text = ""+inv.inventory[i].stackAmount;
						
					}else text.text = "";
					
				}else{ invImages[i].sprite = defaultSprite;text.text = "";}
			}
		}
	}

	protected Rect GetScreenRect(RectTransform rectTransform)
	{
		Vector3[] corners = new Vector3[4];
		rectTransform.GetWorldCorners(corners);
		float xMin = float.PositiveInfinity;
		float xMax = float.NegativeInfinity;
		float yMin = float.PositiveInfinity;
		float yMax = float.NegativeInfinity;
		for (int i = 0; i < 4; i++)
		{
			// For Canvas mode Screen Space - Overlay there is no Camera; best solution I've found
			// is to use RectTransformUtility.WorldToScreenPoint) with a null camera.
			Vector3 screenCoord = RectTransformUtility.WorldToScreenPoint(null, corners[i]);
			if (screenCoord.x < xMin)
				xMin = screenCoord.x;
			if (screenCoord.x > xMax)
				xMax = screenCoord.x;
			if (screenCoord.y < yMin)
				yMin = screenCoord.y;
			if (screenCoord.y > yMax)
				yMax = screenCoord.y;
		}
		Rect result = new Rect(xMin, -yMin, xMax - xMin, yMax - yMin);
		return result;
	}
}
