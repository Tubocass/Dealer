 using UnityEngine;
using System.Collections;

public class LevelingSystem : MonoBehaviour {

	public string xpText;
	public string weedStat;
	public string bitchesStat;
	int curXp = 0;
	int maxXp = 100;
	int level = 1;
	int totalWeed = 0;
	int totalBitchesSlapped = 0;



	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		player.GetComponent<Old_Inventory>().SoldWeed+=LevelWeed;
		player.GetComponent<Player_Interactions>().PickedUpWeed+=WeedGather;

					}

	void OnGUI()
	{
		GUI.Box(new Rect(0,0,200,40), "" + (xpText) + "\n" + "Health: 100  Cash:    " + (weedStat)  + (bitchesStat));

	}

	void Update () {
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


	void WeedGather()
	{
		totalWeed++;
	}
	void LevelWeed() 
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