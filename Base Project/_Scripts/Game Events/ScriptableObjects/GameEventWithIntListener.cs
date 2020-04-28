using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
	[Serializable]
	public class UnityEventInt : UnityEvent<Int32> { }
	public class GameEventWithIntListener : MonoBehaviour
	{
		public GameEventWithInt @event ;
		public UnityEventInt @response;

		private void OnEnable()
		{
			@event.RegisterListener(this);
		}

		private void OnDisable()
		{
			@event.UnregisterListener(this);
		}

		public void OnEventRaised(int value)
		{
			@response.Invoke(value);
		
		}
	
	
	}
}