using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

	PlayerControls pc;

	void Start(){
		pc = GetComponent<PlayerControls> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Death")) {
			pc.Die();
		}
	}
}
