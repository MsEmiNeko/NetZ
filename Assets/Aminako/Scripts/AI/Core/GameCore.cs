using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCore : MonoBehaviour {

	public BaseAI			gameAI 		= null;		// Указатель на игровую логику
	public Item				ItemInHand	= null;		// Предмет в руке
	public cSpeedPanel		SpeedPanel	= null;
	public CoreInventory 	PlayerInventory = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (ItemInHand != null)
			if (ItemInHand.isInHand == false)
				ItemInHand.isInHand = true;
	}

	// Update is called once per frame
	void FixedUpdate  () {
		bool isGUI = false;
		if (ItemInHand != null)
		{
			if ((ItemInHand.IsSubInv) && (ItemInHand.GetComponent<SubInventory>().isVisible)) isGUI = true;
			if (!isGUI)
			{
				if (Input.GetButton ("Use1")) gameAI.OnUse1(ItemInHand);
				if (Input.GetButton ("Use2")) gameAI.OnUse2(ItemInHand);
				if (Input.GetButton ("Use3")) gameAI.OnUse3(ItemInHand);
				if (Input.GetButtonUp ("Reload")) gameAI.OnReload(ItemInHand);
			}
			else
			{
				if (Input.GetButton ("Use2")) gameAI.OnUse2(ItemInHand);
			}
			if ((Input.GetButtonUp ("OpenUI")) && (ItemInHand.IsSubInv)) ItemInHand.GetComponent<SubInventory>().TogleWindow();
		}
		if (Input.GetButton ("Inventory")) PlayerInventory.TogleCoreInvGui();
		float wh = Input.GetAxis ("Mouse ScrollWheel");
		if (SpeedPanel != null)
		{
			if ((wh != 0) && (!isGUI))
			{
				//Debug.Log("WH = " + wh.ToString());
				int st = Mathf.RoundToInt(wh / 0.1f);
				int si = SpeedPanel.SelectedItem + st;
				while (si < 1) si = si + SpeedPanel.SlotCount;
				while (si > SpeedPanel.SlotCount) si = si - SpeedPanel.SlotCount;
				SpeedPanel.SelectItem(si);
			}
		}
	}


}
