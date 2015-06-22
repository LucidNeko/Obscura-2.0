using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	private static Transform m_LastCheckpoint;
	public static Transform LastCheckpoint {
		get { return m_LastCheckpoint; }
		set { m_LastCheckpoint = value; }
	}

	private Transform m_Player;

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			LastCheckpoint = this.transform;
		}
	}


	void Update() {
		if (Input.GetKeyDown (KeyCode.M)) {
			Camera.main.GetComponent<CameraControls>().LookAt(LastCheckpoint.position, 1, 2);
		}
	}
}
