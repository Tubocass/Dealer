using UnityEngine;
using System.Collections;

public class DialogueHandler : MonoBehaviour 
{
	void Awake()
	{
		Dialoguer.Initialize();
	
	}
	void Start()
	{
		addDialoguerEvents();
		Dialoguer.StartDialogue(DialoguerDialogues.First);
	}

	public void addDialoguerEvents()
	{
		Dialoguer.events.onStarted += onDialogueStartedHandler;
		Dialoguer.events.onEnded += onDialogueEndedHandler;
		Dialoguer.events.onInstantlyEnded += onDialogueInstantlyEndedHandler;
		Dialoguer.events.onTextPhase += onDialogueTextPhaseHandler;
		Dialoguer.events.onWindowClose += onDialogueWindowCloseHandler;
		Dialoguer.events.onMessageEvent += onDialoguerMessageEvent;
	}
	
	private void onDialogueStartedHandler()
	{
		Debug.Log("D Satrted");
	}
	
	private void onDialogueEndedHandler()
	{

	}
	
	private void onDialogueInstantlyEndedHandler()
	{
	
	}
	
	private void onDialogueTextPhaseHandler(DialoguerTextData data)
	{
		

	}
	
	private void onDialogueWindowCloseHandler()
	{
	
	}
	
	private void onDialoguerMessageEvent(string message, string metadata)
	{
		switch(message)
		{
			case "Sell":
			{
				string[] meta = metadata.Split(',');
			break;
			}

		}
	}

}
