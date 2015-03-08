using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClickSell : MonoBehaviour, IPointerClickHandler  
{
	public NPC_UI ui;
	Inventory inv;

	public void OnPointerClick(PointerEventData pointer)
	{
		if(pointer.button == PointerEventData.InputButton.Right)
		{
			int index  = transform.GetSiblingIndex();
			inv = ui.Inventory;
			Item item = inv.inventory[index];
			if(item.itemName!=null)
			{
				Inventory tradeInventory = inv.UniqueID>0? Inventory.Find_Inventory(0): Inventory.Find_Inventory(GameObject.FindGameObjectWithTag("GameController").GetComponent<NPC_UI>().Inventory.UniqueID);
				if(tradeInventory!=null)
				{
					Debug.Log(ui.manager.CurrentMarket.name);
					Debug.Log(ui.manager.CurrentMarket.playerReputation);
					int value = ui.manager.CurrentMarket.SellValue(item);
					if(tradeInventory.money>= value)
					{
						inv.Trade(tradeInventory,item,value);
					}	
				}
			}
		}
	}
}
