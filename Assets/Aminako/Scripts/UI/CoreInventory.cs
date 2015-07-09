using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CoreInventory : CloseEvent {
	public GameObject			BtnClose = null;
	public List<SubInventory> 	RootInventorys = new List<SubInventory>();
	public float				InvReopen = 0.6f;				// Задержка перед повторным крафтом
	[HideInInspector]
	public float				NextInvReoperTime = 0.0F;				// Служедная переменная следующего использования
	[HideInInspector]
	public bool					isShovedInv = false;
	private Window				HWND = null;

	// Use this for initialization
	void Start () {
		HWND = gameObject.GetComponent<Window> ();
		NextInvReoperTime = Time.time; 
		foreach (SubInventory ri in RootInventorys)
		{
			//ri.TogleWindow(isShovedInv);
		}
		BtnClose.SetActive (isShovedInv);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TogleCoreInvGui()
	{
		if (Time.time >= NextInvReoperTime)
		{
			NextInvReoperTime = Time.time + InvReopen; 
			isShovedInv = !isShovedInv;
			//HWND.TogleWindow(isShovedInv);
			foreach (SubInventory ri in RootInventorys)
			{
				ri.TogleWindow(isShovedInv);
			}
			BtnClose.SetActive (isShovedInv);
		}
	}

	public override void OnClose ()
	{
		if (Time.time > NextInvReoperTime)
		{
			isShovedInv = false;
			foreach (SubInventory ri in RootInventorys)
			{
				ri.TogleWindow(isShovedInv, false);
			}
			BtnClose.SetActive (isShovedInv);
		}
	}

}
