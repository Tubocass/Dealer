using UnityEngine;
using System.Collections;

public class OnScreenTxt : MonoBehaviour {

	bool showText = true;
	Rect textArea = new Rect(200,300,Screen.width, Screen.height);
	Inventory inv;
	
	void Start () {
		bool showText = true;


	}

	void Update () {
		if (GameObject.FindGameObjectWithTag("Weed") == null)
			//GameObject.Find("Player").transform.position = new Vector3(0,18,0);
			//Application.LoadLevel("Scene_0_");

			inv.AddItem(5);
			

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

