using UnityEngine;
using System.Collections;


/*
 * A simple script with functions that get called by different player scripts to play their respective audio clips.
 */
public class PlayerAudio : MonoBehaviour {
	

	public AudioClip pickupClip;
	
	[Range(0.0F, 1.0F)]
	public float pickupVolume = 0.4F;


	public AudioClip jumpClip;

	[Range(0.0F, 1.0F)]
	public float jumpVolume = 0.4F;

	public AudioClip spinClip;

	[Range(0.0F, 1.0F)]
	public float spinVolume = 0.4F;

	public AudioClip dieClip;

	[Range(0.0F, 1.0F)]
	public float dieVolume = 0.4F;

	public AudioClip splashClip;
	
	[Range(0.0F, 1.0F)]
	public float splashVolume = 0.4F;

	AudioSource source;



	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	public void jump(){
		source.PlayOneShot (jumpClip, jumpVolume);
	}

	public void spin(){
		source.PlayOneShot (spinClip, spinVolume);
	}

	public void die(){
		source.PlayOneShot (dieClip, dieVolume);
	}

	public void splash(){
		source.PlayOneShot (splashClip, splashVolume);
	}

	public void pickup(){
		source.PlayOneShot (pickupClip, pickupVolume);
	}
	
}
