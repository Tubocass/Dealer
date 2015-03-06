using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class RightClickSell : MonoBehaviour, IPointerClickHandler  
{
	public NPC_UI ui;
	Inventory inv;
	SceneChange scn;
	//Inventory inv;



	public void OnPointerClick(PointerEventData pointer)
	{
		int index  = transform.GetSiblingIndex();
		inv = ui.Inventory;
		Item item = inv.inventory[index];
		if(pointer.button == PointerEventData.InputButton.Right)
		{
			Debug.Log("tig ol bitties");

			if(item.itemName!=null)
			{
				Inventory tradeInventory = inv.UniqueID>0? Inventory.Find_Inventory(0): Inventory.Find_Inventory(GameObject.FindGameObjectWithTag("GameController").GetComponent<NPC_UI>().Inventory.UniqueID);
				if(tradeInventory!=null)
				{
					int value = item.itemValue;
					if(tradeInventory.money>= value)
					{
						inv.Trade(tradeInventory,item,value);

					}
				}
			}
		}

		if((pointer.button == PointerEventData.InputButton.Middle))
		{
			
			Debug.Log ("Oh Shit, I'm High");
			scn = GameObject.Find("Player").GetComponent<SceneChange>();
			scn.BeginFade(1);
			scn.SceneTimer();
			inv.RemoveItem(item);
		} 

		}


}
