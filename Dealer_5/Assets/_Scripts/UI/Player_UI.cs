using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player_UI : NPC_UI {
	[SerializeField] public RectTransform mapPanel, mapList;
	[SerializeField] List<string> locations = new List<string>();
	[SerializeField] int locationAmount = 8;
	bool showMaps;
	List<UnityEngine.UI.Button> mapSlots = new List<UnityEngine.UI.Button>();
	// Use this for initialization
	protected override void Start () 
	{
		Inventory = GetComponent<Inventory>();
		Journal = GetComponent<Quest_Journal>();
		itemAmount = Inventory.inventory.Count;
		questAmount = Journal.quests.Count;
		base.Start();

		for (int m = 0; m<locationAmount; m++)
		{
			GameObject icon = (GameObject)Instantiate(buttonPrefab);
			icon.transform.SetParent(mapList);
			
			mapSlots.Add(icon.GetComponent<UnityEngine.UI.Button>());
			mapSlots[m].onClick.AddListener(() => { TravelTo(); });
			icon.SetActive(true);
		}

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
	protected override void OnGUI()
	{
		base.OnGUI();
		
		if(panelUI!=null && showUI)
		{
			if(inv!=null && showInventory)
			{
				DrawInventory();
			}else if(journ!=null && showQuests) 
			{
				DrawQuests();
			}else if(locations!= null&& showMaps)
			{
				DrawLocations();
			}
		}
	}
	public void OnClick_Maps()
	{
		if(showQuests)
		{
			OnClick_Quests();
		}else
		if(showInventory)
		{
			OnClick_Inventory();
		}
		mapPanel.gameObject.SetActive(!mapPanel.gameObject.activeSelf);
		showMaps = !showMaps;
	}
	public virtual void OnClick_Inventory()
	{
		if(showQuests)
		{
			OnClick_Quests();
		}else if (showMaps)
		{
			OnClick_Maps();
		}
		inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
		showInventory = !showInventory;
	}
	public virtual void OnClick_Quests()
	{
		if(showInventory)
		{
			OnClick_Inventory();
		}else if (showMaps)
		{
			OnClick_Maps();
		}
		showQuests = !showQuests;
		journalWindow.gameObject.SetActive(!journalWindow.gameObject.activeSelf);
	}
	protected void DrawLocations()
	{
		for(int j = 0; j< locationAmount;j++)
		{
			Text slotText = mapSlots[j].GetComponentInChildren<Text>();
			if(slotText!=null)
			{
				if(locations[j]!=null)
				{
					slotText.text = locations[j];
				}else slotText.text = "";
			}
		}
	}

	protected void TravelTo()
	{
		int s = events.currentSelectedGameObject.transform.GetSiblingIndex();
		Debug.Log(locations[s]);
		Application.LoadLevel (locations[s]);
	}
}
