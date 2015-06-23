using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

	PlayerControls pc;

	public GameObject Splash;
	PlayerAudio pa;

	void Start(){
		pc = GetComponent<PlayerControls> ();
		pa = GetComponent<PlayerAudio> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Death")) {
			Vector3 location = transform.position;
			Quaternion q = Quaternion.LookRotation(Vector3.up);
			Instantiate(Splash,location,q);


			Camera.main.GetComponent<CameraControls>().LookAt(transform.position, 1, 1.5f);
			pa.splash();
			//pc.Die();
			pc.WaterDie();

		}
		if (other.gameObject.tag.Equals ("Crystal")) {
			pa.pickup();
		}
	}

	Quaternion RandomDirection(){
		return Random.rotation;
		
	}
}
