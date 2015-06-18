using UnityEngine;
using System.Collections;

public class AudioWindScript : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] clips;
	

	float counter = 0.0F;
	float time = 10.0F;

	[Range(0, 100)]
	public float minTime = 60.0F;

	[Range(0, 200)]
	public float maxTime = 180.0F;
	

	void Start(){
		setTime ();
	}

	// Update is called once per frame
	void Update () {

		if(counter > time){
			setTime ();
			counter = 0.0F;
			selectWindClip();
			source.Play();
		}
		counter += Time.deltaTime;
	}

	void selectWindClip(){

		if (clips.Length > 0) {
			source.clip = clips[Random.Range(0, clips.Length - 1)];
		}
	}

	void setTime(){
		time = Random.Range ((minTime), (maxTime));

	}

}
