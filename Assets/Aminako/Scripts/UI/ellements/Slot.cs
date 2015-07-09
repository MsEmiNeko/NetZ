using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
	public RectTransform 	rt 			= null;
	public GameObject 		img			= null;
	public GameObject 		fon			= null;
	public RectTransform 	imgrt		= null;
	public RectTransform 	fonrt		= null;
	public Image			fonimg		= null;
	public Image			imgimg		= null;
	public Color 			FonColor	= Color.white;
	public int 				BorderSize 	= 1;
	public Vector2			SlotSize 	= new Vector2 (20, 20);

	public void SetSize(Vector2 size)
	{
		//Vector2 vSize = new Vector2 (size.x + 5, size.y + 5);
		rt.pivot = new Vector2 (.0f, .0f);
		rt.anchorMin = new Vector2 (0, .0f);
		rt.anchorMax = new Vector2 (0, .0f);
		//rt.anchoredPosition = new Vector2 (0, 0);
		rt.sizeDelta = size;
		Vector2 bsize = new Vector2 (size.x - (BorderSize * 2), size.y - (BorderSize * 2));
		imgrt.pivot = new Vector2 (.5f, .5f);
		imgrt.anchorMin = new Vector2 (.5f, .5f);
		imgrt.anchorMax = new Vector2 (.5f, .5f);
		imgrt.anchoredPosition = new Vector2 (0, 0);
		imgrt.sizeDelta = bsize;
		fonrt.pivot = new Vector2 (.5f, .5f);
		fonrt.anchorMin = new Vector2 (.5f, .5f);
		fonrt.anchorMax = new Vector2 (.5f, .5f);
		fonrt.anchoredPosition = new Vector2 (0, 0);
		fonrt.sizeDelta = bsize;
	}

	public void Translate(Vector2 position)
	{
		rt.anchoredPosition = position;
	}

	// Use this for initialization
	void Awake () {
		rt = gameObject.GetComponent<RectTransform> ();
		img = new GameObject ();
		img.name = "SlotImage";
		img.transform.parent = gameObject.transform;
		imgimg = img.AddComponent<Image> ();
		imgimg.color = FonColor;
		imgrt = img.GetComponent<RectTransform> ();
		fon = new GameObject ();
		fon.name = "SlotFon";
		fon.transform.parent = gameObject.transform;
		fonimg = fon.AddComponent<Image> ();
		fonimg.color = FonColor;
		fonrt = fon.GetComponent<RectTransform> ();
		SetSize (SlotSize);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
