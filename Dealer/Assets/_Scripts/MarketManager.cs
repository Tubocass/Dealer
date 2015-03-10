using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MarketManager : MonoBehaviour 
{

	public List<Market>  market = new List<Market>();
	public string name;
	
	Market currentMarket;

	public Market CurrentMarket
	{ 
		get{return currentMarket;}
	}
	public void ChangeMarket(Market.Location loc)
	{
		currentMarket = market[(int)loc];
		
	}

	void Start()
	{
		currentMarket = market[0];
		//name = currentMarket.name;
		if(CurrentMarket==null)
			Debug.Log("The fuck");
	}
	void OnEnable()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().SoldWeed+=PlayerSale;
	}
	void PlayerSale()
	{
		CurrentMarket.numberOfSales++;
		//float qualityMod = 1-item.itemQuality;
		//playerReputation += qualityMod/100;
	}
	
}
