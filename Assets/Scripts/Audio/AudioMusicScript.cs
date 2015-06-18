using UnityEngine;
using System.Collections;

public class AudioMusicScript : MonoBehaviour {

	public AudioSource source;
	
	public AudioClip musicTrackHappy;
	public AudioClip musicTrackSad;

	public float fadeTime = 5.0F; // Adjusts the time of the fade.

	[Range(0.0F, 0.1F)]
	public float volume = 0.8F; // Adjusts the volume of the music track.

	public bool changeTrack; // Trigger for changing the track.

	bool happy = true; // Keeps track of which track is currently playing.

	// Use this for initialization
	void Start () {
	
		StartCoroutine(fadeIn());
	}
	
	// Update is called once per frame
	void Update () {

		if (changeTrack) {
			StopAllCoroutines(); // Stop any current coroutines so they don't conflict.
			changeTrack = false;

			if (happy) {
				source.clip = musicTrackSad;
				happy = false;
				source.Play();
				StartCoroutine(fadeIn());
			}
			else {
				source.clip = musicTrackHappy;
				happy = true;
				source.Play();
				StartCoroutine(fadeIn());
			}
		}
	}


	IEnumerator fadeIn(){

		float start = 0.0F;
		float end = volume;
		float i = 0.0F;
		float step = 1.0F/fadeTime;
		
		while (i <= 1.0F) {
			i += step * Time.deltaTime;
			source.volume = Mathf.Lerp(start, end, i);
			yield return new WaitForSeconds(step * Time.deltaTime);
		}
	}
}
