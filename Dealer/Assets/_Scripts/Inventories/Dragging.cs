using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Dragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public bool dragOnSurfaces = true;
	public static Item draggedItem;
	static int prevIndex;
	public Inventory inv;
	private GameObject m_DraggingIcon;
	private RectTransform m_DraggingPlane;
	
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		var canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null)
			return;
		
		prevIndex = transform.GetSiblingIndex();
		if(inv.inventory[prevIndex].itemName!=null)
		{
			// We have clicked something that can be dragged.
			// What we want to do is create an icon for this.
			m_DraggingIcon = new GameObject("icon");
			
			m_DraggingIcon.transform.SetParent (canvas.transform, false);
			m_DraggingIcon.transform.SetAsLastSibling();
			
			var image = m_DraggingIcon.AddComponent<Image>();
			// The icon will be under the cursor.
			// We want it to be ignored by the event system.
			CanvasGroup group = m_DraggingIcon.AddComponent<CanvasGroup>();
			group.blocksRaycasts = false;
			
			image.sprite = GetComponent<Image>().sprite;
			image.SetNativeSize();
		
			draggedItem = new Item(inv.inventory[prevIndex]);
			inv.inventory[prevIndex] = new Item();
			
			if (dragOnSurfaces)
				m_DraggingPlane = transform as RectTransform;
			else
				m_DraggingPlane = canvas.transform as RectTransform;
			
			SetDraggedPosition(eventData);
			
		}
		
		
	}
	
	public void OnDrag(PointerEventData data)
	{
		if (m_DraggingIcon != null)
			SetDraggedPosition(data);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (m_DraggingIcon != null)
			Destroy(m_DraggingIcon);
	}

	public void OnDrop(PointerEventData data)
	{
		containerImage.color = normalColor;
		
		int index  = receivingImage.transform.GetSiblingIndex();
		Text text = receivingImage.GetComponentInChildren<Text>();
		if(inv.inventory[index].itemName!=null)
		{
			inv.inventory[prevIndex] = inv.inventory[index];
		}
		if(draggedItem != null)
		{
			inv.inventory[index] = draggedItem;
			draggedItem = null;
		}
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
			m_DraggingPlane = data.pointerEnter.transform as RectTransform;
		
		var rt = m_DraggingIcon.GetComponent<RectTransform>();
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = m_DraggingPlane.rotation;
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

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}
	
	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}
}