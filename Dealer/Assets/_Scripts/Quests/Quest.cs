using UnityEngine;
using System.Collections;
public class Quest : MonoBehaviour
{
	public Quest_Item quest1;
	protected Quest_Journal journal;
	protected Quest_Database questDB;
	protected Old_Inventory inv;
	protected GameObject player;
	public int finalStage;
	
	
	protected virtual void Start () 
	{
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
		player = GameObject.FindGameObjectWithTag("Player");
		inv = GetComponent<Old_Inventory>();
		
		journal = GetComponent<Quest_Journal>();
		if (journal)
		{
			journal.AddItem(quest1);
			journal.Talk+=TalkToQuestGiver;
		}
	}


	public void TalkToQuestGiver()
	{
		if(quest1.questStage >= finalStage)
		{
			quest1.FinishQuest();
			FinishQuest();
		}
	}
	public virtual void FinishQuest()
	{
	}

}
