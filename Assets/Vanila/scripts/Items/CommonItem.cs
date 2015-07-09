using UnityEngine;
using System.Collections;

public class CommonItem : Item {

	public CommonItem() {
		itemType = ItemTypes.Common;
	}

	public override void onItemAction() {
	}
	
	public override void onItemDrop() {
	}
	
	public override void onItemPickUp() {
	}
}
