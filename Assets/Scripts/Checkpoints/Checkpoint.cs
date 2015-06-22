using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	private static Transform m_LastCheckpoint;
	public static Transform LastCheckpoint {
		get { return m_LastCheckpoint; }
		set { m_LastCheckpoint = value; }
	}

	private Transform m_Player;

//	// Use this for initialization
//	void Start () {
//		m_Player = GameObject.FindGameObjectWithTag ("Player").transform;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetKeyDown (KeyCode.R)) {
//			m_Player.transform.position = LastCheckpoint.position;
//		}
//	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			LastCheckpoint = this.transform;
		}
	}
}
