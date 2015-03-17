 using UnityEngine;
using System.Collections;

public class LevelingSystem : MonoBehaviour 
{
	public string xpText;
	public string weedStat;
	int curXp = 0;
	int maxXp = 100;
	int level = 1;
	int totalWeed = 0;

	void Start () 
	{
		GameObject player = GameObject.FindWithTag ("Player");
		player.GetComponent<Inventory>().ItemSold+=LevelWeed;
		player.GetComponent<Inventory>().ItemAdded+=WeedGather;

	}

	void OnGUI()
	{
		GUI.Box(new Rect(0,0,200,40), "" + (xpText) + "\n" + "Health: 100  Cash:    " + (weedStat));

	}

	void Update () 
	{
		xpText = "Level: " + level + "    XP: " + curXp + " / " + maxXp;
		weedStat = "\n\n\n\n" + "Stats" + "\n" + "Grams Gathered:   "   + totalWeed;
	
		if(curXp == maxXp)
		{
			levelUpSystem();
		}
		
	}

	void WeedGather(Item item)
	{
		totalWeed++;
	}
	void LevelWeed(Item item) 
	{
		print ("DING!");
		level++;
	}

	void levelUpSystem () 
	{
			curXp = 0;
			level++;
			maxXp = maxXp + 10;
	}

}