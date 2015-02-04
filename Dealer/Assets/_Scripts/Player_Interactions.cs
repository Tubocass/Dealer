using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour 
{

	Old_Inventory inventory;
	Quest_Journal journal;
	Transform tran;
	LayerMask characterMask;
	public delegate void TradeAction();
	public static event TradeAction PickedUpWeed;
	public GameObject bullet;
	Animator anim;
	int idleHash = Animator.StringToHash("Base Layer.Idle");
	int tokeHash = Animator.StringToHash("Base Layer.Toking");
	
	//public static event TradeAction SoldWeed;
	
	void Start()
	{
		inventory = GetComponent<Old_Inventory>();
		anim = GetComponent<Animator>();
		journal = GetComponent<Quest_Journal>();
		tran = transform;
		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(2);
		characterMask = 1<<9;
			
		//journal.AddItem(1);
		//journal.AddItem(2);
	}

	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			Vector3 fwd = tran.TransformDirection(Vector3.up*3);
			GameObject bulletFired = Instantiate(bullet,tran.position+fwd,transform.rotation)as GameObject;
		}
		if(Input.GetKeyDown("e"))
		{
			Vector3 fwd = tran.TransformDirection(Vector3.up);
			RaycastHit hit;
			Debug.DrawRay(tran.position, fwd, Color.red);
			if (Physics.Raycast(tran.position, fwd, out hit))
			{
				Debug.DrawRay(tran.position, fwd, Color.blue);
				if(hit.collider.gameObject.tag == "NPC")
				{
					Debug.Log("penis");
					hit.collider.gameObject.GetComponent<NPC>().health -=1;
				}
			}
		}
		if(Input.GetKeyDown (KeyCode.L)) 
		{
			OnToke ();

		
		}

				//This is for the swinging animation and for the player to check to see if an NPC is in front of him

				if(Input.GetKeyDown (KeyCode.K)) {
			anim.SetBool("SwingAnim", true);
					}
				else {
						anim.SetBool("SwingAnim", false);
					}
						
						RaycastHit2D hit1 = Physics2D.Raycast (transform.position, transform.up,5, characterMask ); 
					//print (hit.collider.gameObject.tag);
						// add an action for a specific tag here
				if(hit1.collider!=null&& hit1.collider.gameObject.tag == "NPC"){

								Debug.Log ("boom, bitch"); 
						}

					
				else {
						anim.SetBool("SwingAnim", false);
						}
	
	

}


	public void AddWeed()
	{
		inventory.AddItem(1);
		if(PickedUpWeed!=null)
			PickedUpWeed();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
				
		switch (other.gameObject.tag) {
			case "Weed":
			{
				Destroy(other.gameObject,0);
				//print ("something");
				inventory.AddItem(1);
				if(PickedUpWeed!=null)
				PickedUpWeed();
				break;
			}
			case "Drank":
			{
				Destroy(other.gameObject,1);
				//print ("something");
				inventory.AddItem(2);
				break;
			}
			case "Pills":
			{
				Destroy(other.gameObject,1);
				print ("something");
				inventory.AddItem(2);
				break;
			}
			case "Quest":
			{
				//var quest = other.GetComponent<>
				Destroy(other.gameObject,1);
				print ("something");
				journal.AddItem(1);
				break;
			}
			case "Roof":
			{
				other.GetComponent<SpriteRenderer>().enabled = false;
				other.transform.Translate(new Vector3(0,0,1));
				break;
			}


		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Roof":
			{
			other.transform.Translate(new Vector3(0,0,-1));
				other.GetComponent<SpriteRenderer>().enabled = true;
				break;
			}
		}

	}
	public void OnToke()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).nameHash!=tokeHash)
		{//If I'm not alredy in the bite state
			anim.SetBool("Toking",true);
		}
	}
	public void EndToke()
	{
		anim.SetBool("Toking",false);
	}

	IEnumerator MyCoroutine(GameObject obj) 
	{
		//This rotates an object out of view for x secs. For door animations.
		obj.transform.Rotate (0, 90, 0);
		yield return new WaitForSeconds(1);
		obj.transform.Rotate (0, -90, 0);
			
	}


}

		
	
