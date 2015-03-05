using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_Background : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public NPC_UI ui;
	Inventory inv;
	Item draggedItem;
	public static bool bOverInventory;

	public void OnDrop(PointerEventData data)
	{
		draggedItem = Dragging.draggedItem;
		inv = ui.Inventory;
		if(draggedItem.itemOwner != inv.UniqueID)
		{
			int value = draggedItem.itemValue*draggedItem.stackAmount;
			if(inv.money>= value)
			{
				inv.Trade_Dragged(draggedItem,value);
				draggedItem = null;
			}else Dragging.PutBackItem();
		}else{
			Dragging.PutBackItem();
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		bOverInventory = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		bOverInventory = false;
	}

}
