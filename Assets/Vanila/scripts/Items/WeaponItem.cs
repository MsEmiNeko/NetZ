using UnityEngine;
using System.Collections;

public class WeaponItem : Item {

	public WeaponItem() {
		itemType = ItemTypes.Weapon;
	}

	public override void onItemAction() {
	}
	
	public override void onItemDrop() {
	}
	
	public override void onItemPickUp() {
	}
}
