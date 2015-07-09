using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	public int 			Id;
	public string		Name;
	public GameObject	inGameModel;
	public Image		Icon;
	public ItemTypes	itemType;

	public Item() {
		itemType = ItemTypes.Common;
	}

	public virtual void onItemAction() {
	}

	public virtual void onItemDrop() {
	}

	public virtual void onItemPickUp() {
	}



}
