using UnityEngine;
using System.Collections.Generic;
using LitJson;

public class Dialogue: MonoBehaviour{
	
	Dictionary<string, Node> nodeIDs;
	public string firstKey;
	public Node currentNode;
	bool conversing; //IMPROTANT: This field determines whether the dialogue GUI diplays or not.
	//You can modify this script, adding logic to determin when conversing is true.
	//You can also manumpuate it from other scripts using the public property Conversing:
	//public bool Conversing{get{return conversing;} set{conversing = value;}}
	[SerializeField] TextAsset dialogueData;
		
	public class Node {
		public string NPC {get; set;}
		public string ID {get; set;}
		public List<Choice> Choices {get; set;}
		
		public Node (string n,string i, List<Choice> c){
			NPC = n;
			ID = i;			
			Choices = c;
		}
	}
	
	public struct Choice {
		private string target;
		private string player;
		private string action;
		
		public string Target {
			get {return target;}
			set {target = value;}
		}
		public string Player {
			get {return player;}
			set {player = value;}
		}
		public string Action {
			get {return action;}
			set {action = value;}
		}
		public Choice (string playerText, string targetNode){
			player = playerText;
			target = targetNode;
			action = null;
		}
		public Choice (string playerText, string targetNode, string act){
			player = playerText;
			target = targetNode;
			action = act;
		}
	}
	public void NextNode(int i)
	{
		if(i<currentNode.Choices.Count&&currentNode.Choices[i].Target!=null)
		currentNode = nodeIDs[currentNode.Choices[i].Target];
	}

	void LoadData(){
		JsonReader reader = new JsonReader(dialogueData.text);
		int depth = 0;
		string propertyNameTemp = "";
		bool hasSavedNode = false;
		Node nodeTemp;
		string idTemp = "";		
		string npcTextTemp = "";
		List<Choice> choicesTemp = new List<Choice>();
		string playerTextTemp = null;		
		string TargetTemp = "";
		string actionTemp = null;
	
		while (reader.Read ()) 
		{
			if ((reader.Token == JsonToken.ObjectStart) 
				|| (reader.Token == JsonToken.ArrayStart)) 
			{
				depth++;
			}
			else if ((reader.Token == JsonToken.ObjectEnd)
				|| (reader.Token == JsonToken.ArrayEnd)) 
			{
				depth--;
			}
			if (reader.Token == JsonToken.PropertyName) 
			{
				propertyNameTemp = (string)reader.Value;
			}
			else if (depth == 4)
			{	
				if (propertyNameTemp == "Player") 
				{
					playerTextTemp = (string)reader.Value;
				}
				else if (propertyNameTemp == "Target") 
				{
					TargetTemp = (string)reader.Value;
				}
				else if (propertyNameTemp == "Action") 
				{
					actionTemp = (string)reader.Value;
				}
			}
			else if (depth == 2)
			{
				if (propertyNameTemp == "NPC") 
				{
					npcTextTemp = (string)reader.Value;
					hasSavedNode = false;
				}
				else if (propertyNameTemp == "ID") 
				{
					idTemp = (string)reader.Value;
				}
			}else if (depth == 3) 
			{
				if (playerTextTemp != null) 
				{
					if(actionTemp!=null)
					{
						choicesTemp.Add(new Choice(playerTextTemp,TargetTemp,actionTemp));
					}else choicesTemp.Add(new Choice(playerTextTemp,TargetTemp));
					playerTextTemp = null;
				}
			}else if (depth == 1) 
			{
				if (!hasSavedNode) 
				{
					nodeTemp = new Node(npcTextTemp,idTemp,choicesTemp);
					nodeIDs[idTemp] = nodeTemp;
					choicesTemp = new List<Choice>();					
					hasSavedNode = true;
				}
			}
        }
	}

	void Start () 
	{
		//conversing = true;
		nodeIDs = new Dictionary<string, Node>();
		LoadData();
		currentNode = nodeIDs[firstKey];
		//GUICalc();
		//GUIChoicesCalc();
	}	
/*	void Update () {
		if (conversing) {
			for (int i = 1; i <= currentNode.Choices.Count; i ++) {
				if (Input.GetKeyDown(i.ToString())) {
					currentNode = nodeIDs[currentNode.Choices[i-1].Target];
					GUIChoicesCalc();
				}
			}
		}
	}

	public GUISkin customSkin;
	int maxLineLength;
	int lineDimY; 
	float bottomBoxDimY;
	float topBoxDimY;
	int bottomBoxLocY;
	Vector2 topScrollPos;
	int topScrollDimY;
	int topScrollInDimY;
	Vector2 bottomScrollPos;
	int bottomScrollLocY;
	int scrollDimX;
	int bottomScrollDimY;
	int scrollInDimX;
	int bottomScrollInDimY;
	int ChoicesBottom;
	Rect[] ChoiceButtons;
	Rect[] ChoiceLables;
		
	void GUICalc () {
	    lineDimY = 19;
		topBoxDimY = (float)Screen.height*.15f;
		bottomBoxDimY = (float)Screen.height*.35f;
		bottomBoxLocY = Screen.height-(int)bottomBoxDimY;
		topScrollDimY = (int)topBoxDimY -10;
		bottomScrollLocY = (Screen.height-(int)bottomBoxDimY)+5;
		bottomScrollDimY = (int)bottomBoxDimY-10;
		scrollDimX = Screen.width-10;
		scrollInDimX = Screen.width-30;
		maxLineLength = (scrollInDimX-30)/10;	
	}
	public void GUIChoicesCalc () {
		ChoiceButtons = new Rect[currentNode.Choices.Count];
		ChoiceLables = new Rect[currentNode.Choices.Count];
		bottomScrollInDimY = 0;
		int curButtDimY = 0;
		int curButtLocY = 0;
		for (int i=0; i<currentNode.Choices.Count; i++){
			curButtLocY += curButtDimY+5;
			curButtDimY = 0;
			curButtDimY = currentNode.Choices[i].Player.Length/maxLineLength;
			curButtDimY += (currentNode.Choices[i].Player.Length%maxLineLength!=0)?1:0;
			curButtDimY *= lineDimY;
			curButtDimY += 10;
			ChoiceButtons[i] = new Rect(5,curButtLocY,scrollInDimX,curButtDimY);
			ChoiceLables[i] = new Rect(10,curButtLocY+5,scrollInDimX-10,curButtDimY-10);
			bottomScrollInDimY += currentNode.Choices[i].Player.Length/maxLineLength;
			bottomScrollInDimY += (currentNode.Choices[i].Player.Length%maxLineLength!=0)?1:0;
		}
		bottomScrollInDimY *= lineDimY;
		bottomScrollInDimY += currentNode.Choices.Count*15;
		ChoicesBottom = bottomScrollInDimY;
		bottomScrollInDimY += 34;
		topScrollInDimY = currentNode.NPC.Length/maxLineLength;	
		topScrollInDimY += (currentNode.NPC.Length%maxLineLength!=0)?1:0;
		topScrollInDimY *= lineDimY;
		topScrollInDimY += 10;
	}
	/*void OnGUI() {
		if (conversing) {
			GUI.skin=customSkin;
			GUI.Box (new Rect(0, 0, Screen.width,topBoxDimY), "");
			GUI.Box (new Rect(0, bottomBoxLocY, Screen.width, bottomBoxDimY), "");
			topScrollPos = GUI.BeginScrollView(new Rect(5, 5, scrollDimX, topScrollDimY), topScrollPos,
			(new Rect(5, 5, scrollInDimX, topScrollInDimY)));
			GUI.Label (new Rect(5, 10, scrollInDimX, topScrollInDimY), currentNode.NPC);
			GUI.EndScrollView();
			bottomScrollPos = GUI.BeginScrollView(new Rect(5,bottomScrollLocY,scrollDimX,bottomScrollDimY),
			bottomScrollPos,new Rect(5,5,scrollInDimX,bottomScrollInDimY));
			for (int i = 0; i < currentNode.Choices.Count; i++) {
				if (GUI.Button(ChoiceButtons[i],"")){
					currentNode = nodeIDs[currentNode.Choices[i].Target]; 
					GUIChoicesCalc();
				}
				GUI.Label (ChoiceLables[i], (i+1) + ". " + currentNode.Choices[i].Player);

			}
			if (GUI.Button(new Rect(5, ChoicesBottom + 5, scrollInDimX, lineDimY + 10), "")) {
				conversing = false; 
			}
			GUI.Label(new Rect(10, ChoicesBottom+10, scrollInDimX-10, lineDimY+5), "[Suspend conversation]");
			GUI.EndScrollView();
		}
	}
	*/
}