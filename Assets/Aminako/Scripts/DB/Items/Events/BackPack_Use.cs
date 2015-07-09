using UnityEngine;
using System.Collections;

public class BackPack_Use : ItemEvents {

	private SubInventory SubInv = null;

	void Start()
	{
		if (SubInv == null)
			SubInv = gameObject.GetComponent<SubInventory> ();
	}
	public override void OnUse1 ()
	{

	}

	public override void OnUse2 ()
	{
		if (gameObject.GetComponent<SubInventory> ().isVisible)
			gameObject.GetComponent<Window> ().Translate (new Vector2 (100f, 100f));
		else
			SubInv.TogleWindow ();
	}
	
	public override void OnUse3 ()
	{
		//throw new System.NotImplementedException ();
		//Debug.Log ("Use3 Base BackPack");
	}

	public override void OnReload ()
	{
		//throw new System.NotImplementedException ();
		//Debug.Log ("Reload Base BackPack");
	}

	public override void OnCraft ()
	{
		//throw new System.NotImplementedException ();
	}

	public override void OnDrop ()	
	{
		//throw new System.NotImplementedException ();
	}
	public override void OnPickUp ()	
	{
		//throw new System.NotImplementedException ();
	}

}
