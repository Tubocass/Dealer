 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelingSystem : MonoBehaviour {

	public string xpText;
	public string weedStat;
	public string bitchesStat;
	Text stats;
	int curXp = 0;
	int maxXp = 100;
	int health = 100;
	int level = 1;
	int totalWeed = 0;
	int totalBitchesSlapped = 0;
	int dolla = 0;



	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		player.GetComponent<Inventory>().ItemSold+=LevelWeed;
		player.GetComponent<Inventory>().ItemSold+=GetMoney;
		player.GetComponent<Inventory>().ItemAdded+=WeedGather;
		//player.GetComponent<Inventory>().ItemAdded+=PayMoney;

		stats.GetComponent<Text>();
		stats.text =  "Health: 100  Cash: ";

					}

	void OnGUI()
	{
		GUI.Box(new Rect(280,0,200,40), "" + (xpText) + "\n" + "Health: 100  Cash: " + (dolla) + (weedStat)  + (bitchesStat));


	}

	void Update () {
		//stats.text =  "Health: 100  Cash:    ";
		xpText = "Level: " + level + "    XP: " + curXp + " / " + maxXp;
		weedStat = "\n\n\n\n" + "Stats" + "\n" + "Grams Gathered:   "   + totalWeed;
		bitchesStat = "\n" + "Bitches Slapped:   " + totalBitchesSlapped;

		if(curXp == maxXp)
		{
			levelUpSystem();
		}

		if(Input.GetKeyDown (KeyCode.K))
	   {
			print ("go");
			LevelBitches();
		}
						}

	void LevelBitches() 
	{
		print("Bitch, get out the way!");
		totalBitchesSlapped++;
	}
	void GetMoney(Item item)
	{
		dolla = dolla + 10;
	}
	void PayMoney(Item item)
	{
		dolla = dolla - 10;
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