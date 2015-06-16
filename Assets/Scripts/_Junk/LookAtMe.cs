using UnityEngine;
using System.Collections;

public class LookAtMe : MonoBehaviour {

	CameraControls m_Camera;

	// Use this for initialization
	void Start () {
		m_Camera = Camera.main.GetComponent<CameraControls> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			m_Camera.LookAt(transform, 0.5f, 3f);
		}
	}
}
