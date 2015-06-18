using UnityEngine;
using System.Collections;

public class DartAttackScript : MonoBehaviour {

	public GameObject m_ProjectilePrefab;

	private Transform m_ProjectileInstantiationPosition;

	private Animator m_Animator;

	private bool m_CanAttack = true;

	// Use this for initialization
	void Start () {
		m_ProjectileInstantiationPosition = transform.FindChild ("Mouth");
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Fire() {
		if (m_CanAttack) {
			m_CanAttack = false;
			m_Animator.SetTrigger ("Attack");
			yield return new WaitForSeconds (0.2f);
			m_CanAttack = true;
			GameObject projectile = Instantiate (m_ProjectilePrefab, m_ProjectileInstantiationPosition.position, m_ProjectileInstantiationPosition.rotation) as GameObject;
			projectile.GetComponent<ProjectileScript> ().m_Owner = gameObject;
		}
	}
}
