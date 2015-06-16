using UnityEngine;
using System.Collections;



public class footstepAudio : MonoBehaviour {

	public AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		source.Play();
	}
}
