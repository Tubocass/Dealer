using UnityEngine;
using System.Collections;

public class Player_Interactions : MonoBehaviour 
{
	
	Inventory inventory;
	Quest_Journal journal;
	Transform tran;
	public GameObject bullet;
	Animator anim;
	public float strikeDist = 5;
	public LayerMask playerMask;
	GameObject mainCam;
	Transform playerStart;
	
	void Start()
	{
		inventory = GetComponent<Inventory>();
		anim = GetComponent<Animator>();
		journal = GetComponent<Quest_Journal>();
		tran = transform;
		playerStart = GameObject.FindGameObjectWithTag("PlayerStart").transform;
		tran.position = playerStart.position;
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		mainCam.GetComponent<Camera2DFollow>().target = tran;

		inventory.AddItem(1);
		inventory.AddItem(2);
		inventory.AddItem(4);
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
		//This is for the swinging animation and for the player to check to see if an NPC is in front of him
		if(Input.GetKeyDown (KeyCode.F))
		{
			anim.SetTrigger("Swing");
			RaycastHit2D hit1 = Physics2D.Raycast (transform.position, tran.TransformDirection(Vector2.up),strikeDist, playerMask ); 
			//print (hit.collider.gameObject.tag);
			// add an action for a specific tag here
			if(hit1.collider!=null && hit1.collider.gameObject.tag == "NPC" )
			{
				Vector3 dir = tran.position - hit1.transform.position;
				Debug.DrawRay(tran.position, -dir, Color.red);
				Debug.Log (hit1.collider.gameObject.tag); 
				hit1.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				hit1.collider.gameObject.GetComponent<NPC>().health -=1;
			}
		}
	}

	public void UseItem(Item item)
	{
		switch(item.itemName)
		{
			case "Weed":
			{
				break;
			}
			case "Drank":
			{
				break;
			}
			case "Northern Lights":
			{
				Debug.Log ("Oh Shit, I'm High");
				SceneChange scn = GameObject.Find("GameController").GetComponent<SceneChange>();
				
				scn.SceneTimer();
				break;
			}
		}
		inventory.RemoveItem(item);
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag) 
		{
			case "Weed":
			{
				Destroy(other.gameObject,0);
				//print ("something");
				inventory.AddItem(1);
				break;
			}
			case "NorthernLights":
			{
				Destroy(other.gameObject,0);
				//print ("something");
				inventory.AddItem (4);
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
		anim.SetTrigger("Toke");
	}

	
	IEnumerator MyCoroutine(GameObject obj) 
	{
		//This rotates an object out of view for x secs. For door animations.
		obj.transform.Rotate (0, 90, 0);
		yield return new WaitForSeconds(1);
		obj.transform.Rotate (0, -90, 0);
		
	}
	
	
}



