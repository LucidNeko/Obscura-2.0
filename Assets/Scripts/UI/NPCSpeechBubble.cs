using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCSpeechBubble : MonoBehaviour {

	public string[] messagesSetOne; // First set of messages (pre 'taskComplete').
	public string[] messagesSetTwo; // Second set of messages (after 'taskComplete').

	public bool taskComplete; // Used to trigger second set of messages.

	public Text messageText; // Reference to the UI text object.
	public Animator NPCAnimator; // Reference to the animator.
	
	private int numMessages; // The number of messages in the current set.
	private int messageIndex; // The current message being displayed in a set.

	private float readTime = 2.0F; // Adjusts the read time of a message.
	private float charSpeed = 0.05F; // Adjusts how quickly the text writes to screen.


	// Use this for initialization
	void Start () {

	}
	



	void OnTriggerEnter(Collider other){

		// If the player walks into the trigger
		if (other.gameObject.CompareTag ("Player")) {

			// Reset the index to 0
			messageIndex = 0;

			if(taskComplete){
				numMessages = messagesSetTwo.Length;
				startMessageCoroutine(messagesSetTwo);
			}
			else{
				numMessages = messagesSetOne.Length;
				startMessageCoroutine(messagesSetOne);
			}


		}
	}

	void startMessageCoroutine(string [] currentMessages){
		// Make sure there is a message to display
		if (numMessages > 0) {
			
			NPCAnimator.SetBool("showNPCMessage", true);
			
			StartCoroutine (displayMessage (currentMessages [0]));
		}
	}

	void OnTriggerExit(Collider other){
		
		// If the player walks out of the trigger
		if (other.gameObject.CompareTag ("Player")) {
			StopAllCoroutines();
			NPCAnimator.SetBool("showNPCMessage", false);
		}
	}




	/**
	 * Displays each message in order and each message character by character.
	 */
	IEnumerator displayMessage(string str){ 
		
		messageText.text = ""; 
		int i = 0; 
		
		while( messageIndex <= numMessages && i < str.Length){

			messageText.text += str[i++]; 
			
			if( i == str.Length ){

				// Wait for player to read message.
				yield return new WaitForSeconds(readTime);

				// Return the message text to empty.
				messageText.text = ""; 

				// If not the last message.
				if(messageIndex < numMessages -1){
					i = 0; 
					messageIndex ++;
					str = messagesSetOne [messageIndex];
				}
			}
			else{
				// Wait between characters.
				yield return new WaitForSeconds(charSpeed); 
			}
		}

		NPCAnimator.SetBool("showNPCMessage", false);
	}
	


	




}
