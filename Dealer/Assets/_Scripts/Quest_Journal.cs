using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest_Journal : MonoBehaviour {
	string words;
	public int slotsX, slotsY;
	public float beginX, beginY;
	public GUISkin skin;
	protected string tooltip;
	public bool showInventory = false;
	protected bool showTooltip = false;
	public Vector2 scrollPosition = Vector2.zero;
	public List<Quest> inventory = new List<Quest> ();
	public List<Quest> slots = new List<Quest> ();
	Quest_Database questDB;
	protected Rect windowRect;
	public int UniqueID;
	protected void Start()
	{
		for (int i = 0; i<(slotsX*slotsY); i++)
		{
			inventory.Add(new Quest());
			slots.Add(new Quest());

		}
		if(this.gameObject.tag!="Player")
		{
			UniqueID = (int)(Random.value*2000f);
		}

		//AddItem(new Quest("Collection",2,"Collect 5 whole marijuana",Quest.QuestType.Trade,5));
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
	protected void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		
		if(showInventory)
		{

			windowRect = GUI.Window (UniqueID, windowRect, WindowFunction, "My Missions");

		}
	}
	protected void WindowFunction (int windowID) 
	{
		//GUI.BeginGroup(windowRect);
		DrawInventory();
		GUI.Box(new Rect(85,20,windowRect.width-((slotsX*60)+20),windowRect.height-40),new GUIContent(words));
		//GUI.EndGroup();
		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x+15f,Event.current.mousePosition.y+15f,100,50),tooltip);
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
		
	}
	protected void CreateTooltip(Quest q)
	{
		tooltip = q.questName;
	}

	protected void DrawInventory()
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
				slots[i] = inventory[i];
				if(slots[i].questName!=null)
				{
					GUI.Box(slotRect,slots[i].questName);
					if(slotRect.Contains(e.mousePosition))
					{
					
						CreateTooltip(slots[i]);
						showTooltip = true;

						if(e.type==EventType.mouseDown&& e.button==0)
						{
								print ("balls");
								words = slots[i].questDesc;
						}
						if(e.type==EventType.mouseDown&& e.button==1)
						{

								if(UniqueID>1)
								{
									print ("testes");
									Find_Journal(1).AddItem(slots[i]);
								}

								words = slots[i].questDesc;
							}

					}
				}
				i++;
			}
		}
		GUI.EndScrollView();
	}

	public void AddItem(Quest quest)
	{
		if(!ContainsItem(quest.questID))
		{
			for(int i =0;i<inventory.Count;i++)
			{
				if(inventory[i].questName== null)
				{
					inventory[i] = quest;
					break;
				}
			}
		}
	}

	public void AddItem(int id)
	{
		for(int i =0;i<inventory.Count;i++)
		{
			if(inventory[i].questName == null)
			{
				for(int j = 0;j<questDB.quests.Count;j++)
				{
					if(questDB.quests[j].questID==id)
					{
						Quest it = new Quest();
						inventory[i].setQuest(questDB.quests[j]);
						inventory[i].questOwner = this.UniqueID;
						break;
					}
				}break;
			}
		}
	}

	public bool ContainsItem(int id)
	{
		bool result = false;
		for (int i = 0; i<inventory.Count;i++)
		{
			result = inventory[i].questID == id;
			if(result)
			{
				break;
			}
			
		}
		return result;
	}
	public bool ContainsItem(string name)
	{
		bool result = false;
		for (int i = 0; i<inventory.Count;i++)
		{
			result = inventory[i].questName == name;
			if(result)
			{
				break;
			}
			
		}
		return result;
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
