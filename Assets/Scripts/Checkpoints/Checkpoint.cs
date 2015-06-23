using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	private static Vector3 m_LastCheckpoint;
	public static Vector3 LastCheckpoint {
		get { return (m_LastCheckpoint == null) ? Vector3.zero : m_LastCheckpoint; }
		set { m_LastCheckpoint = value; }
	}

	private Transform m_Player;

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			LastCheckpoint = this.transform.position;
		}
	}


	void Update() {
		if (Input.GetKeyDown (KeyCode.M)) {
			Camera.main.GetComponent<CameraControls>().LookAt(LastCheckpoint, 1, 2);
		}
	}
}
