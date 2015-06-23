using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Enums to choose which message to display in Unity's inspector
public enum messageTypes {Camera, Jump, Movement, Spin, Custom};

public class UIMessageScript : MonoBehaviour {


	public GameObject panel; // Panel in UI canvas
	public Text message;
	public messageTypes messageType; // The selected message type
	public string [] customMessages; // The text for the messages if 'Custom' chosen
	public bool repeat; // Set to true in the inspector if the message should appear more than once

	int customMessageNum; // Decides which message to display

	Animator animator; // The animation controller attached to the panel
	bool hasPlayed = false;


	// Use this for initialization
	void Start () {
		animator = panel.GetComponent<Animator>();

	}
	

	void OnTriggerEnter(Collider other)
	{
		if (!hasPlayed || repeat) {
			if(other.gameObject.CompareTag("Player"))
			{
				displayMessage(messageType);
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

	public void setMessageNum(int i){
		if (i < customMessages.Length && i > 0) {
			customMessageNum = i;
		}
	}



	/**
	 *  Sets the text depending on which message type selected in the inspector
	 */

	public void displayMessage(messageTypes type){

		switch (type) {
		case messageTypes.Camera:
			message.text = "Use the right analog stick to move the camera.";
			break;

		case messageTypes.Jump:
			message.text = "Press 'X' to jump";
			break;
		
		case messageTypes.Movement:
			message.text = "Use left analog stick to move.";
			break;
	
		case messageTypes.Spin:
			message.text = "Press Square to glide";
			break;

		case messageTypes.Custom:
			if(customMessages.Length > 0){
				message.text = customMessages[customMessageNum];
			}
			break;
		}
	}

}
