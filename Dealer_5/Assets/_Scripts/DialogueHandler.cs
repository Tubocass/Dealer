using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHandler : MonoBehaviour 
{
	Message dialougueMessage;
	[SerializeField] protected RectTransform DialogueWindow,BranchList, NPCText;
	private bool _dialogue;
	private bool _ending;
	private bool _showDialogueBox;
	private bool _usingPositionRect = false;
	private Rect _positionRect = new Rect(0,0,0,0);
	
	private string _windowTargetText = string.Empty;
	private string _windowCurrentText = string.Empty;
	
	private string _nameText = string.Empty;
	
	private bool _isBranchedText;
	private string[] _branchedTextChoices;
	private int _currentChoice;
	
	private string _theme;
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
		_dialogue = true;
	}
	
	private void onDialogueEndedHandler()
	{
		_ending = true;
	}
	
	private void onDialogueInstantlyEndedHandler()
	{
		_dialogue = false;
		_showDialogueBox = false;
	}
	
	private void onDialogueTextPhaseHandler(DialoguerTextData data)
	{
		_usingPositionRect = data.usingPositionRect;
		_positionRect = data.rect;


		_windowCurrentText = string.Empty;
		_windowTargetText = data.text;
		
		_nameText = data.name;
		
		_showDialogueBox = true;
		
		_isBranchedText = data.windowType == DialoguerTextPhaseType.BranchedText;
		_branchedTextChoices = data.choices;
		_currentChoice = 0;
		Draw ();

	}
	
	private void onDialogueWindowCloseHandler()
	{
		onDialogueInstantlyEndedHandler ();
	}
	
	private void onDialoguerMessageEvent(string message, string metadata)
	{
		Debug.Log("Message detected");
		switch(message)
		{
			case "Trade":
			{
				dialougueMessage.Type = MessageType.Trade;
				dialougueMessage.StringValue = metadata;
				MessageBus.Instance.SendMessage(dialougueMessage);
			break;
			}

		}
	}

	public void Draw()
	{
		Text qtext = NPCText.GetComponentInChildren<Text>();
	}

}
