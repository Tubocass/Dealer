 using UnityEngine;
using System.Collections;

public class LevelingSystem : MonoBehaviour {

	public string xpText;
	int curXp = 0;
	int maxXp = 100;
	int level = 1;
	int totalWeed = 0;


	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		player.GetComponent<Old_Inventory>().SoldWeed+=LevelWeed;
		}

	void OnGUI()
	{
		GUI.Box(new Rect(100,100,180,180),""+(xpText));
	}

	void Update () {
		xpText = "Level: " + level + "    XP: " + curXp + " / " + maxXp;

		if(curXp == maxXp)
		{
			levelUpSystem();
		}
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