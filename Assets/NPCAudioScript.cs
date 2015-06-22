using UnityEngine;
using System.Collections;

public class NPCAudioScript : MonoBehaviour {

	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	


		void OnTriggerEnter(Collider other){

		// If the player walks into the trigger
		if (other.gameObject.CompareTag ("Player")) {
			source.Play ();
		}
	}
}
