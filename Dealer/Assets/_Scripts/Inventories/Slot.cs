using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Slot : MonoBehaviour 
{
	int prevIndex;
	public NewQJ inv;
	Text text;
	Image image;
	
	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image>();
		text = GetComponentInChildren<Text>();
	}
	
	public void OnDrag()
	{
		image.sprite = null;
		text.text = "";
		
	}
}
