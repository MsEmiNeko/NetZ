using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//[ExecuteInEditMode]
public class TaskWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject 	Window = null;
	public Vector3		startmpos;


	public void OnEndDrag (PointerEventData eventData)
	{
	}

	void IDragHandler.OnDrag (PointerEventData eventData)
	{
		Window.transform.position = Input.mousePosition - startmpos;
	}

	void IBeginDragHandler.OnBeginDrag (PointerEventData eventData)
	{
		startmpos = Input.mousePosition - Window.transform.position;
	}

	void Start () {
		if (Window == null)
			Window = transform.parent.gameObject;
	}
}
