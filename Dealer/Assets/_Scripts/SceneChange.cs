using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {


	void Update () {

			if (Input.GetKeyDown ("n"))
			{
				Application.LoadLevel ("Scene_1");
				transform.position = new Vector3(0,0,0);
				
			}
		}
	}

