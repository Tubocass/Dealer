using UnityEngine;
using System.Collections;

public class DoNotDestroySingleton : MonoBehaviour 
{
	public static DoNotDestroySingleton instance = null; 
	                          
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    

		DontDestroyOnLoad(gameObject);
}


}
