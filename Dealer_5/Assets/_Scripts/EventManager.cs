using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{
	public delegate void TradeAction();
	public static event TradeAction PickedUpWeed;

}
