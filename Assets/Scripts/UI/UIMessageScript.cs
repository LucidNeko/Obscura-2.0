using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Enums to choose which message to display in Unity's inspector
public enum messageTypes {Camera, Jump, Movement, Spin, Custom};

public class UIMessageScript : MonoBehaviour {


	public GameObject panel; // Panel in UI canvas
	public Text message;
	public messageTypes messageType; // The selected message type
	public string customMessage; // The text for the message if 'Custom' chosen
	public bool repeat; // Set to true in the inspector if the message should appear more than once

	Animator animator; // The animation controller attached to the panel
	bool hasPlayed = false;


	// Use this for initialization
	void Start () {
		animator = panel.GetComponent<Animator>();
		displayMessage(messageType);
	}
	

	void OnTriggerEnter(Collider other)
	{
		if (!hasPlayed || repeat) {
			if(other.gameObject.CompareTag("Player"))
			{

				animator.SetBool("showUI", true);
			}
		}
	}
	
	
	void OnTriggerExit(Collider other)
	{
		if (!hasPlayed || repeat) {
			if(other.gameObject.CompareTag("Player"))
			{
				hasPlayed = true;
				animator.SetBool("showUI", false);
			}
		}
	}


	/**
	 *  Sets the text depending on which message type selected in the inspector
	 */

	public void displayMessage(messageTypes type){

		switch (type) {
		case messageTypes.Camera:
			message.text = "Bla bla camera";
			break;

		case messageTypes.Jump:
			message.text = "Bla bla jump";
			break;
		
		case messageTypes.Movement:
			message.text = "Bla bla movement";
			break;
	
		case messageTypes.Spin:
			message.text = "Bla bla spin";
			break;

		case messageTypes.Custom:
			if(customMessage != null){
				message.text = customMessage;
			}
			break;
		}
	}

}
