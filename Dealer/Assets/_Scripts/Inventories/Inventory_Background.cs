using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_Background : MonoBehaviour, IDropHandler
{
	public NPC_UI ui;
	Inventory inv;
	Item draggedItem;

	public void OnDrop(PointerEventData data)
	{
		draggedItem = Dragging.draggedItem;
		inv = ui.Inventory;
		if(draggedItem.itemOwner != inv.UniqueID)
		{
			int value = draggedItem.itemValue*draggedItem.stackAmount;
			if(inv.money>= value)
			{
				Debug.Log("Did it get Added?");
				Inventory tradeInventory = Inventory.Find_Inventory(draggedItem.itemOwner);
				inv.AddMoney(-value);
				tradeInventory.AddMoney(value);
				tradeInventory.ItemSoldEvent(draggedItem);
				inv.AddItem(draggedItem);
				draggedItem = null;
			}
		}else{
			//Debug.Log("I'm inside you"+  eventData.position+eventData.pointerEnter);
			Inventory prevInv = Inventory.Find_Inventory(draggedItem.itemOwner);
			prevInv.inventory[Dragging.prevIndex] = draggedItem;
			draggedItem = null;
		}
	}

}
