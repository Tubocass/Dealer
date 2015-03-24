using UnityEngine;
using System.Collections;

public class HighQuest : MonoBehaviour {

	Inventory inv;
	bool showText = true;
	Rect textArea = new Rect(200,300,Screen.width, Screen.height);
	bool addLint = true;
	
	void Start () {
		bool showText = true;
		inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

	}

	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Weed") == null)
		{
			if(addLint)
			{
				SceneChange sn1 = new SceneChange();
				sn1.BeginFade(1);
				inv.AddItem(5);
				addLint = false;
				Application.LoadLevel("Scene_JD");

			}
		}
	}

	void OnGUI()
	{
		if(showText)
		{
			Rect textArea = new Rect(200,300,Screen.width, Screen.height);
			GUI.Label(textArea,"Woah, where did all this weed come from?" + "\n" + " I should totally pick this up and sell it.");
			StartCoroutine(FadeTextCoroutine());
		}
		
	}

	public IEnumerator FadeTextCoroutine() 
	{
		yield return new WaitForSeconds(5);
		showText = false;
	}
}

