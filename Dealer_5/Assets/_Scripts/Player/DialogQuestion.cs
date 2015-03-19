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

}
