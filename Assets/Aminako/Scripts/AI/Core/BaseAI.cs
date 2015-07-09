using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Базовый (корневой или нулевой) обработчик логики.
public class BaseAI : MonoBehaviour {

	public List<Item> 			ItemListeners 		= new List<Item>(); 		// Предметы ожидающие ответа
	public List<BaseModelAI> 	ModelListeners 		= new List<BaseModelAI>(); 	// Модели ожидающие ответа

	public virtual void OnUse1(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time >= ItemInHand.NextReUse1Time && ItemInHand.ReUse1Time > 0)
		{
			ItemInHand.NextReUse1Time = Time.time + ItemInHand.ReUse1Time; 
			ItemInHand.EventID = 1;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}

	public virtual void OnUse2(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time >= ItemInHand.NextReUse2Time && ItemInHand.ReUse2Time > 0)
		{
			ItemInHand.NextReUse2Time = Time.time + ItemInHand.ReUse2Time; 
			ItemInHand.EventID = 2;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}

	public virtual void OnUse3(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time >= ItemInHand.NextReUse3Time && ItemInHand.ReUse3Time > 0)
		{
			ItemInHand.NextReUse3Time = Time.time + ItemInHand.ReUse3Time; 
			ItemInHand.EventID = 3;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}

	public virtual void OnReload(Item		ItemInHand)
	{
		if (ItemInHand.ItemEvent != null && Time.time >= ItemInHand.NextReReloadTime && ItemInHand.ReReloadTime > 0)
		{
			ItemInHand.NextReReloadTime = Time.time + ItemInHand.ReReloadTime; 
			ItemInHand.EventID = 10;
			ItemListeners.Add (ItemInHand);
			OnUseResponde ();
		}
	}

	public virtual void OnUseResponde()
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

	public virtual void OnMoveResponde(Vector3 ToPosition, Vector3 ToRotation)
	{
		while (ItemListeners.Count > 0)
		{
			ModelListeners[0].OnMove(ToPosition, ToRotation);
			ModelListeners.RemoveAt(0);
		}
	}

}
