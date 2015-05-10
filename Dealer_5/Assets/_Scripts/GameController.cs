using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public int _currentInventory,_currentLevel;
	/* Singleton */
	public static GameController instance;

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    
	}
	private GameController() {}
}