using UnityEngine;
using System.Collections;

public class AlterScript : MonoBehaviour {

	private Animator m_Animator;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			m_Animator.SetTrigger("Activate");
			Camera.main.GetComponent<CameraControls>().Shake(1f, 4f);
			Camera.main.GetComponent<CameraControls>().LookAt(transform.position, 3, 4f);

			GameObject.Find("GlobalScripts").GetComponent<LightingTransition>().Activate();
		}
	}
}
