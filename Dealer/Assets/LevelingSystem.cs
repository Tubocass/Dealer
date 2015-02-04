using UnityEngine;
using System.Collections;

public class LevelingSystem : MonoBehaviour {


	int curXp = 0;
	int maxXp = 100;

	public string xpText;
	int level = 1;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(100,100,140,140),""+(xpText));
	}
	
	// Update is called once per frame
	void Update () {
	
		xpText = "Level: " + level + "    XP: " + curXp + " / " + maxXp;

	


	if(curXp == maxXp) {
	
			levelUpSystem();
		}

	

		if(Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("LEVEL UP!");
			curXp += 10;
	
		}
		}





	void levelUpSystem () {

	
			curXp = 0;
			level++;
			maxXp = maxXp + 10;


			





		}

}