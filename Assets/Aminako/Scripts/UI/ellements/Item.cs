using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Item : MonoBehaviour {
	public bool					isInHand = false;
	public string 				Name;								// Отображаемое имя предмета
	public SlotType				ItemSlotType = SlotType.all;		// Предмет помещается в слотах для (тип слота) 
																	// если указан SlotType.all , то поместить можно в любой слот
	public int					CurentLevel;						// Текущий уровень предмета
	public int					MaxLevel;							// Макисмальный уровень предмета
	public int					Exp;								// Экспа предмета
	public GameObject			ExpTable;							// Таблица прокачки предмета
	public Vector2 				NeedSlots;							// Занимаемое колличество слотов
	public Sprite				ItemSprite = null;					// Изображение предмета
	public GameObject			ItemPrefab = null;					// Модель (префаб) предмета. Для отображения в руке или на земле.
	public List<GameObject> 	Skills = new List<GameObject>();	
	public bool					IsSubInv = false;						// Суб инвентарь. Имеется ли возможность переноса предметов в предмете
	//public SlotType				SubInvSlotType;						// Какие предметы можно помещать в суб инвентарь
	//public int					SubInvSlotCount = 0;				// Количество слотов в суб инвентаре предмета
	public ItemEvents			ItemEvent;							// Скрипт обработки использования предмета
	public float				ReUse1Time = 1.0f;					// Задержка перео повторным использованием
	public float				ReUse2Time = 1.0f;					// Задержка перео повторным использованием
	public float				ReUse3Time = 1.0f;					// Задержка перео повторным использованием
	public float				ReReloadTime = 1.0f;				// Задержка для следующей перезарядки
	public float				ReCraftTime = 1.0f;					// Задержка перед повторным крафтом
	public float				ReDropTime = 1.0f;					// Задержка перед повторным крафтом
	public float				RePickUpTime = 1.0f;				// Задержка перед повторным крафтом
	[HideInInspector]
	public float				NextReUse1Time = 0.0F;				// Служедная переменная следующего использования
	[HideInInspector]
	public float				NextReUse2Time = 0.0F;				// Служедная переменная следующего использования
	[HideInInspector]
	public float				NextReUse3Time = 0.0F;				// Служедная переменная следующего использования
	[HideInInspector]
	public float				NextReReloadTime = 0.0F;			// Служедная переменная следующей перезарядки
	[HideInInspector]
	public float				NextReCraftTime = 0.0F;				// Служебная переменная задержки перед повторным крафтом
	[HideInInspector]
	public float				NextReDropTime = 0.0F;				// Служебная переменная задержки перед повторным крафтом
	[HideInInspector]
	public float				NextRePickUpTime = 0.0F;			// Служебная переменная задержки перед повторным крафтом

	[HideInInspector]
	public int					EventID;							// Идентификатор ожидаемого евента от логики
																	// 1 - Use1
																	// 2 - Use2
																	// 3 - Use3
																	// 10 - Reload
																	// 20 - Craft
	private SubInventory		inInv = null;						// ссылка на инвентарь в котором находится
	private Slot				parentSlot = null;


	void Update() {
		if (Application.isEditor)
		{
			if ((IsSubInv) && (gameObject.GetComponent<SubInventory>() == null))
				gameObject.AddComponent<SubInventory>();
			if ((IsSubInv) && (gameObject.GetComponent<SubInventory>() != null))
				gameObject.GetComponent<SubInventory> ().enabled = true;
			if ((!IsSubInv) && (gameObject.GetComponent<SubInventory> () != null))
				gameObject.GetComponent<SubInventory> ().enabled = false;
		}
	}

	// Use this for initialization
	void Start () {
		if ((IsSubInv) && (gameObject.GetComponent<SubInventory>() == null))
			gameObject.AddComponent<SubInventory>();
		//Debug.Log("Start called.");
		NextReUse1Time = Time.time + ReUse1Time; 
		NextReUse2Time = Time.time + ReUse2Time; 
		NextReUse3Time = Time.time + ReUse3Time; 
		NextReReloadTime = Time.time + NextReReloadTime; 
		NextReCraftTime = Time.time + NextReCraftTime; 
	}

	public void ChangeSlot(Slot value)
	{
		parentSlot = value;
	}
}
