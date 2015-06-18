using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]



public class footstepAudio : MonoBehaviour {

public AudioClip [] clips;



	AudioSource source; // The audio source that will play the footsteps.

	void Start(){
		
		source = GetComponent<AudioSource> (); // Get the audio source object.
	}

	void OnTriggerEnter(Collider other){

		source.clip = clips[Random.Range(0, 6)];
		source.Play(); // Tell the audio source to play the clip.
	}
}
