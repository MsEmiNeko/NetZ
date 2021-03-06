//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18444
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Требуется компонент Window
[RequireComponent(typeof(Window))]
//[ExecuteInEditMode]
public class SubInventory : MonoBehaviour 
{
	public GameObject			SlotPrefab;							// Префаб слота
	public Vector2				SlotSize =  new Vector2(25,25);
	public Vector2 				InvSlots = new Vector2(1,1);		// Размер интерфейса
	public SlotType				SubInvSlotType = SlotType.all;		// Какие предметы можно помещать в суб инвентарь
	private int					SubInvSlotCount = 0;				// Количество слотов в суб инвентаре предмета 
																	// (максимальная вместимость данного инвентаря)
	public List<Item>			Items = new List<Item>();			// Таблица предметов
	private List<GameObject>	Slots = new List<GameObject>();		// Таблица предметов

	public int 					CurentSlotUsed = 0;					// Количество занятых слотов

	private bool				SlotInicialized = false;
	public Color				SelectColor = Color.red;
	public Color				UnSelectColor = Color.gray;
	private Window				SubInvWindow = null;
	public bool					isCore = false;						// Является ли инвентарь корневым (основным, не предметным)
	private Item				selfItem = null;					// Ссылка на предмет инвентарем которого является данный экземпляр класса

	// Инициализация слотов (визульного отображения
	private void InicializeSlots()
	{
		// Если есть префаб слота
		if (SlotPrefab != null)
		{
			int x = 1, y = 1;
			int i;
			// Удалить объекты слотов
			for (i = 0; i < Slots.Count; i++)
				Destroy(Slots[i]);
			// Очистить (обнулить) массов слотов
			Slots.Clear();
			for (i = 0; i < SubInvSlotCount; i++)
			{
				// Определить имя слота
				string slotname = "Slot_" + x.ToString() + "_" + y.ToString();
				// Добавить слот
				Slots.Add(Instantiate(SlotPrefab));
				// Привязать слоты к левому нижнему краю окна
				RectTransform rts = Slots[i].GetComponent<RectTransform>();
				rts.pivot = new Vector2 (0, 0);
				rts.anchorMin = new Vector2 (0, 0);
				rts.anchorMax = new Vector2 (0, 0);
				// Задать имя слота
				Slots[i].name = slotname;
				// Задать фон слота
				Slots[i].GetComponent<Image> ().color = UnSelectColor;
				// Задать координаты слота
				SubInvWindow.AddElement(Slots[i], new Vector3((x - 1) * SlotSize.x + 5, (y - 1) * SlotSize.y + 5, 0)); 
				Slots[i].GetComponent<Slot>().SetSize(new Vector2(SlotSize.x - 5, SlotSize.y - 5));

				// Переути к следующему слоту
				y++;
				if (y > InvSlots.y) 
				{
					y = 1;
					x++;
				}
			}
		}
		SlotInicialized = true;
	}

	// 
	public void Start()
	{
		if (gameObject.GetComponent<Window>() == null)
			gameObject.AddComponent<Window> ();
		SubInvWindow = gameObject.GetComponent<Window> ();
		if (!isCore)
			selfItem = gameObject.GetComponent<Item>();

		//SubInvImage.
		// Ограничение размера инвентаря по минимальным параметром (не позволять выход в нулевое и минусовое значение размеров)
		if (0 == InvSlots.x) InvSlots.x = 1;
		if (0 == InvSlots.y) InvSlots.y = 1;
		// Подсчитать общее число ячеек в инвентаре
		SubInvSlotCount = Mathf.RoundToInt(InvSlots.x) * Mathf.RoundToInt(InvSlots.y);
		SubInvWindow.Size = new Vector2 (InvSlots.x * SlotSize.x + 5, InvSlots.y * SlotSize.y + 5);
	}

	public void Update()
	{
		//if (SubInv == null)
		//	InicializeSlots ();
		// Отобразить инвентарь
		if (!SlotInicialized)
		{
			Vector2 pos = new Vector2 (InvSlots.x * SlotSize.x + 5, InvSlots.y * SlotSize.y + 5);
			SubInvWindow.Resize (pos);
			InicializeSlots ();
		}
	}

	// Получить предмет из ячейки
	public Item GetItem(int index)
	{
		return Items[index];
	}

	// Добавить предмет в ячейку
	public bool AddItem(Item value, int index = -1)
	{
		// Подсчитать размер предмета в слотах
		int needSlots = Mathf.RoundToInt(value.NeedSlots.x) * Mathf.RoundToInt(value.NeedSlots.y);
		// Определить поместится ли предмет в инвентарь
		if (CurentSlotUsed + needSlots <= SubInvSlotCount)
		{
			// Если передан параметр ячейки в которую нужно поместить
			if (index >= 0)
				// Поместить предмет в ячейку сдвинув остальные дальше
				Items.Insert(index, value);
			else
				// Добавить предмет в конце массива. То есть в первый свободный слот
				Items.Add(value);
			CurentSlotUsed += needSlots;
			// Обновить отображение предметов
			UpdateVisible ();
			return true;
		}
		else
			return false;
	}

	//  Поменят предметы местами
	public void ChangeItemPlaces(int indexFrom, int indexTo)
	{
		// Копировать предмет в буфер
		Item temp = Items[indexFrom];
		// Копировать предмет из ячейки в ячейку
		Items [indexFrom] = Items [indexTo];
		// Копировать предмет из буфера
		Items [indexTo] = temp;
		// Обновить отображение предметов
		UpdateVisible ();
	}

	// Обновить отображение предметов
	public void UpdateVisible()
	{
	}

	public void TogleWindow(bool value, bool waite = true)
	{
		if (gameObject.GetComponent<Window>() == null)
			gameObject.AddComponent<Window> ();
		SubInvWindow = gameObject.GetComponent<Window> ();
		SubInvWindow.TogleWindow (value, waite);
	}

	public void TogleWindow()
	{
		SubInvWindow.TogleWindow ();
	}

	public bool isVisible
	{
		get { return SubInvWindow.isVisible; }
	}
}

