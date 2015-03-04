using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC_UI: MonoBehaviour
{
	[SerializeField] protected RectTransform panelUI, inventoryPanel, inventoryGrid, journalWindow,journalList, questText;
	protected Inventory inv;
	public Inventory Inventory{get{return inv;}set{inv = value; OnChange_Inventory();}}
	protected Quest_Journal journ;
	public Quest_Journal Journal{get{return journ;}set{journ = value; OnChange_Journal();}}
	protected bool showInventory, showUI, showQuests;
	List<Image> invSlots = new List<Image>();
	List<UnityEngine.UI.Button> journSlots = new List<UnityEngine.UI.Button>();
	[SerializeField] protected int itemAmount = 6, questAmount = 4;
	protected Rect window;
	public Rect Window{get{return window;}}
	[SerializeField] GameObject imagePrefab, buttonPrefab;
	[SerializeField] EventSystem events;
	Text qtext;

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
		qtext = questText.GetComponentInChildren<Text>();
		window = GetScreenRect((RectTransform)panelUI.transform);
		inventoryPanel.GetComponent<Inventory_Background>().ui = this;
		for (int i = 0; i<itemAmount; i++)
		{
			GameObject icon = (GameObject)Instantiate(imagePrefab);
			icon.transform.SetParent(inventoryGrid);
			
			invSlots.Add(icon.GetComponent<Image>());
			invSlots[i].GetComponent<Dragging>().ui = this;
			invSlots[i].GetComponent<RightClickSell>().ui = this;
			//invSlots[i].GetComponent<Dragging>().inv = inv;
			icon.SetActive(true);
		}
		for (int j = 0; j<questAmount; j++)
		{
			GameObject icon = (GameObject)Instantiate(buttonPrefab);
			icon.transform.SetParent(journalList);

			journSlots.Add(icon.GetComponent<UnityEngine.UI.Button>());
			journSlots[j].onClick.AddListener(() => { DrawQuestText(); });
			icon.SetActive(true);
		}
	}
	
	public void OnClick_Inventory()
	{
		if(showQuests)
		{
			OnClick_Quests();
		}
		inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
		showInventory = !showInventory;
		/*foreach (Image child in invSlots) 
		{
			child.gameObject.SetActive(!child.gameObject.activeSelf);
		}	*/	

	}
	public void OnClick_Quests()
	{
		if(showInventory)
		{
			OnClick_Inventory();
		}
		showQuests = !showQuests;
		journalWindow.gameObject.SetActive(!journalWindow.gameObject.activeSelf);
	}

	public void OnChange_Inventory()
	{
		/*foreach (Image child in invSlots) 
		{
			child.GetComponent<Dragging>().inv = inv;
		}*/		
	}
	
	public void OnChange_Journal()
	{
		if(qtext!=null)
		qtext.text = "";
	}

	public void ShowUI(bool show)
	{
		showUI = show;
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
			}else if(journ!=null && showQuests) 
			{
				DrawQuests();
			}
		}
	}

	protected virtual void DrawInventory()
	{
		for(int i =0; i<inv.inventory.Count;i++)
		{
			Text text = invSlots[i].GetComponentInChildren<Text>();
			if(text!=null)
			{
				if(inv.inventory[i].itemIcon!=null)
				{
					invSlots[i].sprite = (Sprite)inv.inventory[i].itemIcon;
					
					if(inv.inventory[i].bStackable)
					{
						text.text = ""+inv.inventory[i].stackAmount;
						
					}else text.text = "";
					
				}else{ invSlots[i].sprite = null;text.text = "";}
			}
		}
	}
	void DrawQuests()
	{
		for(int j = 0; j< journ.quests.Count;j++)
		{
			Text slotText = journSlots[j].GetComponentInChildren<Text>();
			if(slotText!=null)
			{
				if(journ.quests[j].itemName!=null)
				{
					slotText.text = journ.quests[j].itemName;
				}
			}
		}
	}
	public void DrawQuestText()
	{
		Text qtext = questText.GetComponentInChildren<Text>();

		Debug.Log("Some Text");
		int s = events.currentSelectedGameObject.transform.GetSiblingIndex();
		Debug.Log(s);
		if(qtext!=null)
		qtext.text = journ.quests[s].GetText();
	}

	public Rect GetScreenRect(RectTransform rectTransform)
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
