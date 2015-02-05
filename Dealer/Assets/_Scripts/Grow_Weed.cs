using UnityEngine;
using System.Collections;

public class Grow_Weed : MonoBehaviour {
	float timer;
	public float limit;
	public GameObject prefab,bud;
	bool bBudded, clicked;
	SpriteRenderer sprite;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!bBudded)
		{
			timer+=Time.deltaTime;
			if(timer>=limit)
			{
				timer = 0;
				print("boosh"); 
				bud  = Instantiate(prefab, transform.position,Quaternion.identity) as GameObject;
			}
		}
	}

	public void OnMouseDown() 
	{
		print ("bboobbss");
		clicked = true;
		//inventory.showInventory = true;
		//inventory.AddItem(1);
	}
	public void OnGUI()
	{
		Event e = Event.current;
		Rect trade = new Rect(100,20,100,100);
		if(!sprite.bounds.Contains(e.mousePosition)&& !trade.Contains(e.mousePosition)&& e.type==EventType.mouseDown&& e.button==0)
		{
			//print ("tiiiittttss");
			clicked = false;
			//inventory.showInventory = false;
		}
		if(clicked)
		{
			GUI.BeginGroup(trade);
			if(GUI.Button(new Rect(0,10,90,40),"Plant"))
			{

			}
			if(GUI.Button(new Rect(0,50,90,40),"Harvest"))
			{
				player.GetComponent<Player_Interactions>().AddWeed();
				Destroy(bud,2);
			}
			GUI.EndGroup();
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == bud)
		{
			bBudded = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == bud)
		{
			bBudded = false;
		}
	}
}
