using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_Background : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public NPC_UI ui;
	Inventory inv;
	Item draggedItem;
	public static bool bOverInventory;

	public void OnDrop(PointerEventData data)
	{
		draggedItem = Dragging.draggedItem;
		if(draggedItem != null)
		{
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
	}
	public void OnPointerClick(PointerEventData pointer)
	{
		if(RightClickSell.panel!=null)
		Destroy(RightClickSell.panel.gameObject);
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
