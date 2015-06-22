using UnityEngine;
using System.Collections;

public class CheckpointParticleScript : MonoBehaviour {

	ParticleSystem checkpointParticles;

	// Use this for initialization
	void Start () {
		checkpointParticles = gameObject.GetComponent<ParticleSystem> ();
	}
	


	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			checkpointParticles.enableEmission = false;
		}
	}


	
}
