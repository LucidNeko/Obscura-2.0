using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

	PlayerControls pc;

	public GameObject Splash;

	void Start(){
		pc = GetComponent<PlayerControls> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Death")) {
			Vector3 location = transform.position;
			Instantiate(Splash,location,RandomDirection());
			Camera.main.GetComponent<CameraControls>().LookAt(transform.position, 1, 1.5f);
			pc.Die();
		}
	}

	Quaternion RandomDirection(){
		return Random.rotation;
		
	}
}
