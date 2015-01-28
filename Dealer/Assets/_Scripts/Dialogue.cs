using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour 
{
	Rect windowRect;
	bool showDialogue;
	string words;
	protected  void OnGUI()
	{
		if(showDialogue)
		{
			//windowRect = GUI.Window ();
		}
	}
	protected  void WindowFunction (int windowID) 
	{
		
		//GUI.BeginGroup(windowRect);
		//DrawDialogue();
		//GUI.Box(new Rect(),words);
		
		if(GUI.Button(new Rect(85,windowRect.height-40,100,40),"Sure bud."))//accept a quest
		{
	
			print ("testes");
		
			//words = quests[selectedQuest].GetText();
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
		
	}
}
