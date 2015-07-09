using UnityEngine;
using System.Collections;


public abstract class ItemEvents : MonoBehaviour 
{
	public abstract void OnUse1 ();
	public abstract void OnUse2 ();
	public abstract void OnUse3 ();

	public abstract void OnReload ();
	
	public abstract void OnCraft ();

	public abstract void OnDrop ();
	public abstract void OnPickUp ();
}
