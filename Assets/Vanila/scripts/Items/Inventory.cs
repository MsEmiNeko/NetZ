using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item>	Items = new List<Item>();
	public ItemTypes	avialableType = ItemTypes.Common;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSize(int Size) {
		Items = new List<Item> (Size);
	}
}
