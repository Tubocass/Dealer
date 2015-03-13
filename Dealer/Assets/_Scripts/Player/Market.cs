using UnityEngine;
using System.Collections;
[System.Serializable]
public class Market 
{
	public float playerReputation, numberOfSales, averageQuality, marketVariance;
	public string name;
	public enum Location
	{
		Home = 0, Mall = 1
	}
	public Location location;
	
	public Market(){ marketVariance = 1;}
	public Market(Market market)
	{
		playerReputation = market.playerReputation;
		numberOfSales = market.numberOfSales;
		averageQuality = market.averageQuality;
		marketVariance = market.marketVariance;
		name = market.name;
	}
	public int SellValue(Item item)
	{
		float qualityMod, marketValue;
		int sellValue;
		qualityMod = item.itemQuality-1;

		marketValue = item.itemValue* marketVariance;
		sellValue = Mathf.RoundToInt(marketValue+(qualityMod+playerReputation));
		return sellValue;
	}
	
}

