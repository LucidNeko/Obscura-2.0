using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]


public class AudioFootstepsScript : MonoBehaviour {


	public AudioClip [] clips; // An array of audio clips to alternate between. 

	AudioSource source; // The audio source that will play the footsteps.


	void Start(){
		
		source = GetComponent<AudioSource> (); // Get the audio source object.
	}

	void OnTriggerEnter(Collider other){

		if(clips.Length > 0){
			source.clip = clips[Random.Range(0, clips.Length - 1)]; // Randomly choose an audio clip from the array.
		}

		source.Play(); // Tell the audio source to play the clip.
	}
}
