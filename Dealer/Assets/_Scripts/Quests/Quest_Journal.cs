using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest_Journal : Old_Inventory {
	string words;
	public Vector2 scrollPosition = Vector2.zero;
	Quest_Database questDB;
	public List<Quest_Item> quests = new List<Quest_Item>();

	public delegate void TalkAction();
	public event TalkAction QuestFinished;
	//public event TalkAction FinishQuest;
	public event TalkAction Talk;
	
	protected override void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			//slots.Add(new Quest_Item());
			quests.Add(new Quest_Item());
		}
		if(this.gameObject.tag!="Player")
		{
			UniqueID = (int)(Random.value*2000f);
		}
		windowRect = new Rect (500, 100, 280, 200);
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
	}
	void Update()
	{
		if(Input.GetButtonDown("Journal"))
		{
			if(this.gameObject.tag=="Player")
			showInventory = !showInventory;
		}
	}

	protected override void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		
		if(showInventory)
		{
			windowRect = GUI.Window (UniqueID, windowRect, WindowFunction, "My Missions");
		}
	}
	protected override void WindowFunction (int windowID) 
	{
		
		//GUI.BeginGroup(windowRect);
		DrawInventory();
		GUI.Box(new Rect(85,20,windowRect.width-((slotsX*60)+20),windowRect.height-40),words);
		//GUI.EndGroup();
		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,100,50),tooltip);
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
		
	}
	protected override void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		
		scrollPosition = GUI.BeginScrollView(new Rect(5, 20, 80, 200), scrollPosition, new Rect(0, 0, 60, (slotsY*35)+20));
		for (int y=0;y<slotsY;y++)
		{
			for (int x=0;x<slotsX;x++)
			{
				Rect slotRect = new Rect(5+(x*50),(y*35),50,25);
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				//slots[i] = inventory[i];
				if(quests[i].itemName!=null&&!quests[i].bFinished)
				{
					GUI.Box(slotRect,quests[i].itemName);
					if(slotRect.Contains(e.mousePosition))
					{
						if(!draggingItem)
						{
							CreateTooltip(quests[i]);
							showTooltip = true;
						}
						if(e.type==EventType.mouseDown&& e.button==0)
						{
							print ("balls");
							words = quests[i].itemDesc;
							if(Talk != null)
								Talk();
						}
						if(e.type==EventType.mouseDown&& e.button==1)
						{
							if(UniqueID>1)
							{
								print ("testes");
								Find_Journal(1).AddItem(quests[i].itemID);
								if(!quests[i].bActive)
								{
									quests[i].bActive = true;
								}
							}
							words = quests[i].GetText();
							
							
						}
					}
				}
				i++;
			}
		}
		GUI.EndScrollView();
	}

	public void AddItem(Quest_Item item)
	{
		int s = ContainsItemAt(item.itemID);
		if(item.itemID<1||s>-1)
		{
			return;
			
		}else
		{
			for(int i =0;i<quests.Count;i++)
			{
				if(quests[i].itemName == null)
				{
					quests[i] = item;
					quests[i].itemOwner = this.UniqueID;
					break;
				}
			}
		}
			

	}
	public override int ContainsItemAt(int id)
	{
		for (int i = 0; i<quests.Count;i++)
		{
			if(quests[i].itemID == id)
			{
				return i;
				break;
			}
			
		}
		return -1;
	}

	public override void AddItem(int id)
	{
		int s = ContainsItemAt(id);
		if(id<1||s>-1)
		{
			return;
			
		}else
		{
			for(int i =0;i<quests.Count;i++)
			{
				if(quests[i].itemName == null)
				{
					for(int j = 0;j<questDB.items.Count;j++)
					{
						if(questDB.items[j].itemID==id)
						{
							Quest_Item it = new Quest_Item(questDB.items[j]);
							quests[i] = it;
							quests[i].itemOwner = this.UniqueID;
							break;
						}
					}break;
				}
			}
		}
	}

	public static Quest_Journal Find_Journal(int id)
	{
		Quest_Journal[] inv = FindObjectsOfType<Quest_Journal>();
		for(int i =0; i<inv.Length;i++)
		{
			if( inv[i].UniqueID == id)
			{ return inv[i];}
		}
		return null;
	}
}
