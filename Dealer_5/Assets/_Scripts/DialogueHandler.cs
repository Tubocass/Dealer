using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueHandler : MonoBehaviour 
{
	Message dialougueMessage;
	[SerializeField] protected RectTransform DialogueWindow,BranchList, NPCText;
	protected List<UnityEngine.UI.Button> choiceSlots = new List<UnityEngine.UI.Button>();
	[SerializeField] protected GameObject buttonPrefab;
	[SerializeField] protected EventSystem events;
	Text qtext;

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
		qtext = NPCText.transform.GetComponent<Text> ();
		for (int j = 0; j<4; j++)
		{
			GameObject icon = (GameObject)Instantiate(buttonPrefab);
			icon.transform.SetParent(BranchList);
			
			choiceSlots.Add(icon.GetComponent<UnityEngine.UI.Button>());
			choiceSlots[j].onClick.AddListener( ()=> {
				int s = events.currentSelectedGameObject.transform.GetSiblingIndex(); 
				Dialoguer.ContinueDialogue(s); 
				Draw();
			});
			icon.SetActive(true);
		}
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
		Debug.Log("D Starrted");
		_dialogue = true;
		OnClickButton ();
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
	public void OnClickButton()
	{
		//_showDialogueBox = !_showDialogueBox;
		DialogueWindow.gameObject.SetActive (!DialogueWindow.gameObject.activeSelf);
		//.gameObject.SetActive (!NPCText.gameObject.activeSelf);
	}
	void OnGUI()
	{
		if (_showDialogueBox) 
		{
			Draw();
		}
	}

	public void Draw()
	{

		if(qtext!=null)
		qtext.text = _windowTargetText;
		if(_isBranchedText)
		{
			for(int c = 0; c<_branchedTextChoices.Length;c++)
			{
				Text slotText = choiceSlots[c].transform.GetComponentInChildren<Text>();
				if(_branchedTextChoices[c]!=null)
				{
					slotText.text = _branchedTextChoices[c];
				}else slotText.text = "";
			}
		}
	}

}
