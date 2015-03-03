using UnityEngine;
using System.Collections;

public class Daily_Balance : MonoBehaviour 
{
	float timer = 0;
	public float limit;
	public delegate void BalanceAction();
	public static event BalanceAction Costs;
	
	void Start () 
	{
		
	}
	void OnGUI()
	{
		GUI.Box(new Rect(20,20,60,60),""+Mathf.Floor(timer));
	}

	void Update () 
	{
		timer+=2*Time.deltaTime;
		if(timer>=limit)
		{
			timer = 0;
			print("boosh"); 
			if(Costs!=null)Costs();
		}
	}
}
