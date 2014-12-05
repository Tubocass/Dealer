using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	Inventory inventory;
	
	void Start()
	{

		DontDestroyOnLoad (this.gameObject);
		inventory = GetComponent<Player_Inventory>();
		inventory.AddItem(1);
		inventory.AddItem(2);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
				switch (other.gameObject.tag) {
		
				case "Weed":
						{
								Destroy (other.gameObject, 1);
								print ("something");
								inventory.AddItem (1);
								break;
						}
				case "Drank":
						{
								Destroy (other.gameObject, 1);
								print ("something");
								inventory.AddItem (2);
								break;
						}
				case "Pills":
						{
								Destroy (other.gameObject, 1);
								print ("something");
								inventory.AddItem (2);
								break;
						}
				case "Door":
						{
								
								
								StartCoroutine (MyCoroutine(other.gameObject));
								
								
								break;
						}
				}
		}
			IEnumerator MyCoroutine(GameObject obj) 
		{
				//This rotates an object out of view for x secs. For door animations.
				obj.transform.Rotate (0, 90, 0);
				yield return new WaitForSeconds(1);
				obj.transform.Rotate (0, -90, 0);
	
				
		}

	}


	



