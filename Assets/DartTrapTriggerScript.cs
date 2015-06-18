using UnityEngine;
using System.Collections;

public class DartTrapTriggerScript : MonoBehaviour {

	private DartAttackScript m_DartTrap;

	// Use this for initialization
	void Start () {
		m_DartTrap = GetComponentInParent<DartAttackScript> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<ProjectileScript> () == null) { //if a projectile didn't hit it
			StartCoroutine (m_DartTrap.Fire ());
		}
	}
}
