using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class RightClickSell : MonoBehaviour, IPointerClickHandler  
{
	public NPC_UI ui;
	Inventory inv;
	GameObject panel;
	private RectTransform m_DraggingPlane;
	[SerializeField] Image panelFab;
	[SerializeField] UnityEngine.UI.Button buttFab;
	[SerializeField] Canvas can;
	SceneChange scn;
	//Inventory inv;



	public void OnPointerClick(PointerEventData pointer)
	{
		var canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null)
			return;
		if(pointer.button == PointerEventData.InputButton.Right)
		{
			int index  = transform.GetSiblingIndex();
			m_DraggingPlane = canvas.transform as RectTransform;
			inv = ui.Inventory;
			Item item = inv.inventory[index];
			if(item.itemName!=null)
			{
				panel = Instantiate(panelFab.gameObject,pointer.position,Quaternion.identity)as GameObject;
				//panel.AddComponent<Image>();
				panel.transform.SetParent(canvas.transform,false);
				panel.transform.SetAsLastSibling();
				SetPosition(pointer);
				Inventory tradeInventory = inv.UniqueID>0? Inventory.Find_Inventory(0): Inventory.Find_Inventory(GameObject.FindGameObjectWithTag("GameController").GetComponent<NPC_UI>().Inventory.UniqueID);
				if(tradeInventory!=null)
				{
					int value = ui.manager.CurrentMarket.SellValue(item);
					
					UnityEngine.UI.Button sellButton = Instantiate(buttFab) as UnityEngine.UI.Button;
					sellButton.transform.SetParent(panel.transform, false);
					sellButton.GetComponentInChildren<Text>().text = "Sell";
					sellButton.onClick.AddListener(() => 
					{ 
						if(tradeInventory.money>= value)
						{
							inv.Trade(tradeInventory,item,value);
						} Destroy(panel.gameObject);
					});
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


	
	
	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();
		
		if (comp != null)
			return comp;
		
		Transform t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
	
	private void SetPosition(PointerEventData data)
	{
		if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
			m_DraggingPlane = data.pointerEnter.transform as RectTransform;
		
		var rt = panel.GetComponent<RectTransform>();
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = m_DraggingPlane.rotation;
		}
	}
}
