using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We need to add the Unity.UI library to access UI elements.
using UnityEngine.UI;

/// <summary>
/// This class is in charge of 
/// </summary>
public class UIController : MonoBehaviour
{
	// UI elements
	public Button ButtonSendMessage;
	public InputField InputField;
	public Text MessageDisplay;

	// Use this for initialization
	void Start()
	{
		// Subscribe our 'SendMessage' method to m_ButtonSendMessage onClick events
		// Therefore: everytime we click on the button, 'SendMessage' will be called.
		ButtonSendMessage.onClick.AddListener(SendMessageUpdateRequest);

		// Also, subscribe 
		EventController.OnMessageUpdateRequest += UpdateMessage;
	}

	void SendMessageUpdateRequest()
	{
		// Store the input field's text into a string
		string message = InputField.text;

		EventController.Event_OnMessageUpdateRequest(message);
	}

	void UpdateMessage(string _message)
	{
		// Print it (Debugging purposes)
		Debug.LogFormat("-- UIController // Updating message: {0}", _message);

		// Update our message display text with the contents of the message variable
		MessageDisplay.text = _message;

		// Reset the text of our input field
		InputField.text = "";
	}
	
	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		// Unsubscribe from our methods
		ButtonSendMessage.onClick.RemoveListener(SendMessageUpdateRequest);

		EventController.OnMessageUpdateRequest -= UpdateMessage;
	}
}