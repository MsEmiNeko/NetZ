using UnityEngine;
using System.Collections;

public class BackackItem : Item {

	public Inventory inventory;

	public BackackItem(int Slots = 1) {
		itemType = ItemTypes.BackPack;
		inventory.SetSize (Slots);
	}

	public override void onItemAction() {
	}
	
	public override void onItemDrop() {
	}
	
	public override void onItemPickUp() {
	}
}
