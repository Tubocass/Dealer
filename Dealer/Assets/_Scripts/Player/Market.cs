using UnityEngine;
using System.Collections;

public class Market : MonoBehaviour 
{
	public float playerReputation, numberOfSales, averageQuality, marketVariance;
	public string name;

	void OnEnable()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().SoldWeed+=PlayerSale;
	}

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
		qualityMod = 1-item.itemQuality;

		marketValue = item.itemValue* marketVariance;
		sellValue = Mathf.RoundToInt(marketValue*(qualityMod+playerReputation));
		return sellValue;
	}
	void PlayerSale(Item item)
	{
		numberOfSales++;
		float qualityMod = 1-item.itemQuality;
		playerReputation += qualityMod/100;
	}
}

