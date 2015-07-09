using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class cSpeedPanel : MonoBehaviour {

	public int 					SelectedItem 	= 1;
	public GameObject 			SlotPrefab 		= null;
	public int					SlotCount		= 3;
	public List<GameObject>	Slots				= new List<GameObject>();
	public bool					SlotsCreated	= false;
	public Color				SelectColor 	= Color.red;
	public Color				UnSelectColor 	= Color.gray;

	void InitSlots()
	{
		if (SlotPrefab != null)
		{
			int i;
			Slots.Clear();
			for (i = 0; i < SlotCount; i++)
			{
				Slots.Add(Instantiate(SlotPrefab));
				Slots[i].transform.parent = gameObject.transform;
				//Slots[i].transform.Translate(i * 25 + 15 + gameObject.transform.position.x, gameObject.transform.position.y, 0);
				Slots[i].name = "Slot" + i.ToString();
				Slots[i].GetComponent<Image> ().color = UnSelectColor;
				Slots[i].GetComponent<Slot> ().Translate(new Vector2(i * 25 + 15 + gameObject.transform.position.x, 0));
			}
			SlotsCreated = true;
		}
	}

	// Use this for initialization
	void Start () {
		InitSlots ();
		SelectItem (SelectedItem);
	}
	//*
	void OnDestroy()
	{
		while (Slots.Count > 0)
		{
			Slots.RemoveAt(0);
		}
		SlotsCreated = false;
	}
	//*/
	// Use this for initialization
	void update () {
		//if (!SlotsCreated) InitSlots ();
	}

	public void SelectItem(int index)
	{
		Slots[index - 1].GetComponent<Image> ().color = SelectColor;
		if (index != SelectedItem) Slots[SelectedItem - 1].GetComponent<Image> ().color = UnSelectColor;
		SelectedItem = index;
	}
}
