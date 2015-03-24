using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class DialogQuestion
{
	public enum QuestionType
	{
		Quest, Info
	}
	public bool precondition;
	public QuestionType type;
	public string question;
	public List<DialogAnswer> answers = new List<DialogAnswer>();

	public static DialogAnswer ChooseAnswer(DialogQuestion question)
	{
		foreach(DialogAnswer answer in question.answers)
		{
			if(answer.type == DialogAnswer.AnswerType.Agree && answer.precondition)
			{
				return answer;
			}else if(answer.type == DialogAnswer.AnswerType.Disagree && answer.precondition)
			{
				return answer;
			}else if(answer.type == DialogAnswer.AnswerType.Indifferent)
			{
				return answer;
			}
		}
		return null;
	}

}
