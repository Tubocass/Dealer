using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest_Database : MonoBehaviour{

	public List<Quest> quests = new List<Quest> ();

	void Start()
	{
		//AddQuest(new Quest("Payment",3,"Collect 5 whole marijuana",Quest.QuestType.Trade,5));
		//quests[1] = new Quest("Collection",1,"Collect 5 whole marijuana",Quest.QuestType.Trade,5);
	}

public bool ContainsItem(int id)
	{
		bool result = false;
		for (int i = 0; i<quests.Count;i++)
		{
			result = quests[i].questID == id;
			if(result)
			{
				break;
			}
			
		}
		return result;
	}

	public void AddQuest(Quest quest)
	{
		for(int i =0;i<quests.Count;i++)
		{
			if(quests[i] == null)
			{
				quests[i] = quest;
				break;
			}
		}
	}
}
