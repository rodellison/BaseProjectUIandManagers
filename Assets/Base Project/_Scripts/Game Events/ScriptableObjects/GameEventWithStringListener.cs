using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
	[Serializable]
	public class UnityEventString : UnityEvent<String> { }
	public class GameEventWithStringListener : MonoBehaviour
	{
		public GameEventWithString @event ;
		public UnityEventString @response;

		private void OnEnable()
		{
			@event.RegisterListener(this);
		}

		private void OnDisable()
		{
			@event.UnregisterListener(this);
		}

		public void OnEventRaised(String value)
		{
			@response.Invoke(value);
		
		}
	
	
	}
}