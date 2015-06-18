using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public GameObject m_Owner;

	public float m_Speed = 1f;
	public float m_Lifetime = 5f;

	private float m_CurrentLifetime = 0f;

	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * m_Speed, ForceMode.VelocityChange);
		StartCoroutine (Die (5));
	}

	public IEnumerator Die(float time) {
		if (time > 0) {
			yield return new WaitForSeconds(time);
		}

		Destroy(gameObject);
			
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.transform.root.gameObject != m_Owner) {

			StartCoroutine (Die (0));
		}
	}
}
