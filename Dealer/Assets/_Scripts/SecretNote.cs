using UnityEngine;
using System.Collections;
[System.Serializable]
public class SecretNote : Quest
{
	Quest_Database questDB;
	public int weedAmount = 0;
	void Start()
	{
		questDB = GameObject.FindGameObjectWithTag ("QuestDatabase").GetComponent <Quest_Database> ();
		questDB.AddQuest(this);
	}
	public SecretNote()
	{
		//quest = questDB.items[2];
		//quest.itemName = "Secret Note";
		//quest.itemDesc = "Collect 5 whole marijuana";
		//Player_Interactions.PickedUpWeed+= IncreaseSupply;
	}
	void OnEnable()
	{
		Player_Interactions.PickedUpWeed+= IncreaseSupply;
	}
	void OnDisable()
	{
		Player_Interactions.PickedUpWeed-= IncreaseSupply;

	}
	void IncreaseSupply()
	{

		weedAmount+=1;
		Debug.Log(weedAmount);
		if(weedAmount==4)
		{

			EndQuest();
		}
	}
	void hitTarget()
	{
		//CreateInstance<>();
	}
	void Update()
	{
		if(weedAmount==4)
		{
			//Debug.Log("You 5 marijuanas");
			//EndQuest();
		}
	}
	void EndQuest()
	{
		bFinished = true;
		Debug.Log("You have 5 marijuanas");
	}


}
