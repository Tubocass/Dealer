using UnityEngine;
using UnityEngine.Events;
using System.Collections;
[System.Serializable]
public class DialogAnswer
{
	public enum AnswerType
	{
		Agree, Disagree, Indifferent
	}
	public AnswerType type;
	public string answer;
	public bool precondition;
	//public UnityEvent Selected;
	public DialogEvent customE;
	public DialogAnswer(string Answer, DialogAnswer.AnswerType Type)
	{
		answer = Answer;
		type = Type;
	}
	
}
