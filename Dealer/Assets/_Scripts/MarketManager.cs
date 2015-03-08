using UnityEngine;
using System.Collections;

public class MarketManager : MonoBehaviour {

	Market market;
	public string name;
	public enum MarketLocation
	{
		Home = 0, Mall = 1
	}
	public MarketLocation location;
	Market currentMarket;
	public Market CurrentMarket{ get{return currentMarket;}}

	void Start()
	{
		market = new Market();
		location = MarketLocation.Home;
		market.marketVariance = 2f;
		market.name = "Da Corner";
		currentMarket = market;
		name = currentMarket.name;
		if(CurrentMarket==null)
			Debug.Log("The fuck");
	}
}
