using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
	//public List<DialogQuestion> subQuestion = new List<DialogQuestion>();

	public DialogAnswer(string Answer, DialogAnswer.AnswerType Type)
	{
		answer = Answer;
		type = Type;
	}
	
}
