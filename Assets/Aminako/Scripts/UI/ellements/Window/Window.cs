using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Window : MonoBehaviour {

	private Canvas				CanvaCanv;
	public GameObject			Canva;								// Отображаемый объект интенфейса инвентаря
	public GameObject			WindowFon;							// Отображаемый объект интенфейса инвентаря
	public GameObject			Head;								// Отображаемый объект интенфейса инвентаря
	private GameObject			CloseBTN;							// Отображаемый объект интенфейса инвентаря
	private Image				WindowFonImage;						// Фон панели интерфейса инвнтаря
	private Image				HeadImage;							// Фон панели интерфейса инвнтаря
	private Image				CloseBTNImage;						// Фон панели интерфейса инвнтаря
	private RectTransform 		WindowFonRT;		
	private RectTransform 		HeadRT;		

	public Color				HeadColor = Color.green;			// Цвет фона инвентаря
	public Color				CloseBTNColor = Color.magenta;		// Цвет фона инвентаря
	public Color				FonColor = Color.grey;				// Цвет фона инвентаря
	public Color				SelectColor = Color.red;
	public Color				UnSelectColor = Color.gray;


	public bool					isDragable = true;					// Претаскиваемое ли окно
	public Vector2				Position = new Vector2(100,100);
	public Vector2				Size;
	[HideInInspector]
	public float				NextTogle = 0.0F;					// Служедная переменная следующего использования
	[HideInInspector]
	public float				WaiteTogle = 0.5F;					// Служедная переменная следующего использования
	public Sprite				WindowFonBackground = null;
	public Image.Type			WindowFonImageType = Image.Type.Sliced;
	public Sprite				HeadBackground = null;
	public Image.Type			HeadImageType = Image.Type.Sliced;
	public WindowHeadType		HeadType = WindowHeadType.HalfWindowSize;
	public int					HeadWidth = 100;
	public Sprite				CloseBTNBackground = null;
	public Image.Type			CloseBTNImageType = Image.Type.Sliced;

	// Use this for initialization
	void Start () 
	{
		InitWindows ();
	}

	public void InitWindows()
	{
		NextTogle = Time.time; 
		// Если нет канваса, создать его
		if (Canva == null)
		{
			Canva = new GameObject();
			Canva.transform.parent = gameObject.transform;
			CanvaCanv = Canva.AddComponent<Canvas> ();
			Canva.AddComponent<CanvasScaler> ();
			Canva.AddComponent<GraphicRaycaster> ();
			Canva.name = "InventoryCanva";
			CanvaCanv.renderMode = RenderMode.ScreenSpaceOverlay;
		}
		// Если нет панели, создать ее
		if (WindowFon == null)
		{
			WindowFon = new GameObject();
			WindowFon.transform.parent = Canva.transform;
			WindowFon.SetActive (false);
			WindowFon.name = "InventoryUI";
			// Получить указатель на фон панели
			WindowFonImage = WindowFon.AddComponent<Image> ();
			//WindowFonImage = WindowFon.GetComponent<Image> ();
			WindowFonImage.sprite = WindowFonBackground;
			WindowFonImage.type = WindowFonImageType;
			WindowFonImage.color = FonColor;
			// Установить размер и позицию холста в требуемый размер 
			WindowFonRT = WindowFon.GetComponent<RectTransform>();
			WindowFonRT.pivot = new Vector2 (0, 0);
			WindowFonRT.anchorMin = new Vector2 (0, 0);
			WindowFonRT.anchorMax = new Vector2 (0, 0);
			WindowFonRT.anchoredPosition = Position;
		}
		if (Head == null)
		{
			Head = new GameObject();
			Head.transform.parent = WindowFon.transform;
			Head.name = "InventoryUIHead";
			Head.AddComponent<Image> ();
			Head.AddComponent<TaskWindow> ();
			HeadImage = Head.GetComponent<Image> ();
			HeadImage.sprite = HeadBackground;
			HeadImage.type = HeadImageType;
			HeadImage.color = HeadColor;
			// Настройка отображения заголовка
			HeadRT = Head.GetComponent<RectTransform>();
			HeadRT.pivot = new Vector2 (0, 1);
			HeadRT.anchorMin = new Vector2 (0, 1);
			HeadRT.anchorMax = new Vector2 (0, 1);
			HeadRT.anchoredPosition = new Vector2 (0, 0);
		}
		if (CloseBTN == null)
		{
			CloseBTN = new GameObject();
			CloseBTN.transform.parent = WindowFon.transform;
			CloseBTN.name = "InventoryUICloseBTN";
			CloseBTN.AddComponent<Image> ();
			CloseBTN.AddComponent<CloseWindow> ();
			CloseBTNImage = CloseBTN.GetComponent<Image> ();
			CloseBTNImage.sprite = CloseBTNBackground;
			CloseBTNImage.type = CloseBTNImageType;
			CloseBTNImage.color = CloseBTNColor;
			// Настройка отображения заголовка
			RectTransform cbtn = CloseBTN.GetComponent<RectTransform>();
			cbtn.pivot = new Vector2 (1, 1);
			cbtn.anchorMin = new Vector2 (1, 1);
			cbtn.anchorMax = new Vector2 (1, 1);
			cbtn.anchoredPosition = new Vector2 (0, 0);
			cbtn.sizeDelta = new Vector2(10,10);
		}
		//Resize (Size);
	}

	void Update()
	{
		Head.SetActive (isDragable);
		CloseBTN.SetActive (isDragable);
	}

	public void Resize (Vector2 value)
	{
		Vector2 lSize;
		lSize.x = value.x;
		if (isDragable)
			lSize.y = value.y + 10;
		else
			lSize.y = value.y;
		WindowFonRT.sizeDelta = lSize;

		switch (HeadType)
		{
			case WindowHeadType.FixedSize : 
				lSize.x = HeadWidth; 
				break;
			case WindowHeadType.FullWindowSize :
				lSize.x = value.x - 15;
				break;
			case WindowHeadType.HalfWindowSize:
				lSize.x = Mathf.RoundToInt(value.x / 2);
				break;

		}
		lSize.y = 10;
		HeadRT.sizeDelta = lSize;
	}

	public void Translate(Vector2 position)
	{
		WindowFonRT.anchoredPosition = position;
	}

	public void AddElement(GameObject element, Vector2 position)
	{
		element.transform.parent = WindowFon.transform;
		element.GetComponent<Slot> ().Translate(new Vector2(position.x, 
		                                                    position.y));
	}

	public void TogleWindow(bool value, bool waite = true)
	{
		if (waite)
		{
			if (Time.time >= NextTogle)
			{
				WindowFon.SetActive (value);
				NextTogle = Time.time + WaiteTogle; 
			}
		}
		else
		{
			WindowFon.SetActive (value);
			NextTogle = Time.time + WaiteTogle; 
		}
	}

	public void TogleWindow()
	{
		TogleWindow(!WindowFon.activeSelf);
	}

	public bool isVisible
	{
		get { return WindowFon.activeSelf; }
	}
}
