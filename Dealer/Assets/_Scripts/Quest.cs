using UnityEngine;
using System.Collections;
[System.Serializable]
public class Quest : MonoBehaviour
{
	public string questName;
	public int questID;
	public string questDesc;
	public QuestType questType;
	public enum QuestType
	{
		Collection, Dropoff, Trade
	}
	public int questReward;
	public bool bPreConditionsMet;
	public bool bActive;
	public bool bFinished;
	public int questStage = 0;
	public Item questItem;
	public int questOwner;
	public Quest(){}
	public void setQuest(string name, int id, string desc, QuestType type, int reward)
	{
		questName = name;
		questID = id;
		questDesc = desc;
		questType = type;
		questReward = reward;
	}
	public void setQuest(Quest item)
	{
		questName = item.questName;
		questID = item.questID;
		questDesc = item.questDesc;
		questType = item.questType;
	}

}
