using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
	// The delegate is our signature-- Define your parameters between the parentheses
	public delegate void OnMessageUpdateRequestDelegate(string _message);
	
	// This will be the delegate we're subscribing towards
	public static OnMessageUpdateRequestDelegate OnMessageUpdateRequest;

	public static void Event_OnMessageUpdateRequest(string _message)
	{
		Debug.LogFormat("-- EventController // Received a request to update message: {0}", _message);
		OnMessageUpdateRequest(_message);
	}
}