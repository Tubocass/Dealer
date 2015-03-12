using UnityEngine;
using System.Collections;

 
public class Loader : MonoBehaviour 
{
	public GameObject doNotDestroy;

	void Awake ()
	{
		//DontDestroyOnLoad(this.gameObject);
		if (DoNotDestroySingleton.instance == null)
		{
			Instantiate(doNotDestroy);
		}

		GetComponent<Camera2DFollow>().target = GameObject.FindGameObjectWithTag("Player").transform;
	}
}
