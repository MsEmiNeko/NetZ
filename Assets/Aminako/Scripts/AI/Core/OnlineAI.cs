using UnityEngine;
using System.Collections;

public class OnlineAI : BaseAI {

	public override void OnUse1(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time > ItemInHand.NextReUse1Time)
		{
			ItemInHand.NextReUse1Time = Time.time + ItemInHand.ReUse1Time; 
			print ("Use1 item " + ItemInHand.Name);
			ItemInHand.EventID = 1;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}
	
	public override void OnUse2(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time > ItemInHand.NextReUse2Time)
		{
			ItemInHand.NextReUse2Time = Time.time + ItemInHand.ReUse2Time; 
			print ("Use2 item " + ItemInHand.Name);
			ItemInHand.EventID = 2;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}
	
	public override void OnUse3(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time > ItemInHand.NextReUse3Time)
		{
			ItemInHand.NextReUse3Time = Time.time + ItemInHand.ReUse3Time; 
			print ("Use3 item " + ItemInHand.Name);
			ItemInHand.EventID = 3;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}
	
	public override void OnReload(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time > ItemInHand.NextReReloadTime)
		{
			ItemInHand.NextReReloadTime = Time.time + ItemInHand.ReReloadTime; 
			print ("Reload item " + ItemInHand.Name);
			ItemInHand.EventID = 10;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}
	
	public override void OnUseResponde()
	{
		while (ItemListeners.Count > 0)
		{
			switch (ItemListeners[0].EventID)
			{
			case 1 :	ItemListeners[0].ItemEvent.OnUse1(); break;
			case 2 :	ItemListeners[0].ItemEvent.OnUse2(); break;
			case 3 :	ItemListeners[0].ItemEvent.OnUse3(); break;
			case 10 :	ItemListeners[0].ItemEvent.OnReload(); break;
			default :	ItemListeners[0].ItemEvent.OnUse1(); break;
			}
			ItemListeners.RemoveAt(0);
		}
	}
	
	public override void OnMoveResponde(Vector3 ToPosition, Vector3 ToRotation)
	{
		while (ItemListeners.Count > 0)
		{
			ModelListeners[0].OnMove(ToPosition, ToRotation);
			ModelListeners.RemoveAt(0);
		}
	}
}
