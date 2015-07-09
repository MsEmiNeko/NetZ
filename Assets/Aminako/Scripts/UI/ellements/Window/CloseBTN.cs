using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CloseBTN : MonoBehaviour, IPointerDownHandler {

	public CloseEvent 	eventListener = null;
	#region IPointerDownHandler implementation
	void IPointerDownHandler.OnPointerDown (PointerEventData eventData)
	{
		eventListener.OnClose();
	}
	#endregion

}
