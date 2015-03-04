using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClickSell : MonoBehaviour, IPointerClickHandler  
{

	public void OnPointerClick(PointerEventData pointer)
	{
		if(pointer.button == PointerEventData.InputButton.Right)
		{
			Debug.Log("tig ol bitties");
		}
	}
}
