using UnityEngine;
using System.Collections;

public class LookAtMe : MonoBehaviour {

	CameraControls camera;

	// Use this for initialization
	void Start () {
		camera = Camera.main.GetComponent<CameraControls> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			camera.LookAt(transform, 3f);
		}
	}
}
