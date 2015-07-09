using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CloseWindow : MonoBehaviour, IPointerDownHandler {

	private GameObject 	Window = null;
	#region IPointerDownHandler implementation
	void IPointerDownHandler.OnPointerDown (PointerEventData eventData)
	{
		Window.SetActive (false);
	}
	#endregion

	// Use this for initialization
	void Start () {
		if (Window == null)
			Window = transform.parent.gameObject;
	}
	
}
