using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour {

	NewQJ inventory;
	Quest_Journal journal;
	public delegate void TradeAction();
	public static event TradeAction PickedUpWeed;
	public GameObject bullet;


	//public static event TradeAction SoldWeed;
	
	void Start()
	{


		inventory = GetComponent<NewQJ>();
		journal = GetComponent<Quest_Journal>();

		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(2);
		//journal.AddItem(1);
		//journal.AddItem(2);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
				
				switch (other.gameObject.tag) {
		
				case "Weed":
						{
								Destroy (other.gameObject, 1);
								print ("something");
								inventory.AddItem (1);
								if (PickedUpWeed != null)
										PickedUpWeed ();
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
				case "Quest":
						{
								//var quest = other.GetComponent<>
								Destroy (other.gameObject, 1);
								print ("something");
								journal.AddItem (1);
								break;
						}
		
				case "Door":
						{
								//Destroy (other.gameObject);
								Debug.Log ("door");
								StartCoroutine (MyCoroutine (other.gameObject));
								break;
						}
				case "Roof":
						{
								
								
								
								other.GetComponent<SpriteRenderer>().enabled = false;
									
								
								
								break;
								
						}
						


				}

	}
	void OnTriggerExit2D( Collider2D other)
	{
		other.GetComponent<SpriteRenderer>().enabled = true;

	}


	void Update() {


	if (Input.GetKeyDown ("space")) {
			Instantiate(bullet, transform.position, Quaternion.identity);
		}

		}


	void OnCollisionEnter(Collision col) {

	


	



					}
				IEnumerator MyCoroutine(GameObject obj) 
				{
						//This rotates an object out of view for x secs. For door animations.
						obj.transform.Rotate (0, 90, 0);
						yield return new WaitForSeconds(1);
						obj.transform.Rotate (0, -90, 0);
			
				}


}
		
		
	
