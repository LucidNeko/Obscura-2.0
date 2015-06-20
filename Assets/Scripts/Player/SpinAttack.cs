using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]

public class SpinAttack : MonoBehaviour {
	
	public float m_NumRotations = 2;
	public float m_Duration = 0.5f; //seconds
	public float m_ForwardForce = 5f;
	public float m_UpwardForce = 7f;
	public PlayerAudio m_audioScript;

	private bool m_IsAttacking = false;
	private Rigidbody m_RigidBody;
	private Animator m_Animator;


	// Use this for initialization
	void Start () {
		m_RigidBody = GetComponent<Rigidbody> ();
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_IsAttacking && Input.GetButtonDown("Attack")) {
			m_IsAttacking = true;
			m_Animator.SetBool("Attack", m_IsAttacking);
			m_audioScript.spin(); // Play Spin Audio
			StartCoroutine(Spin());
		}
	}

	public IEnumerator Spin() {
		float time = 0;

		m_RigidBody.AddForce (m_RigidBody.transform.forward * m_ForwardForce, ForceMode.Impulse);
		m_RigidBody.AddForce (Vector3.up * m_UpwardForce, ForceMode.VelocityChange);

		Vector3 start = m_RigidBody.transform.eulerAngles;
		Vector3 end = new Vector3 (start.x, start.y + 360 * m_NumRotations, start.z);

		do {
			m_RigidBody.transform.eulerAngles = Vector3.Lerp(start, end, time / m_Duration);
			yield return null;
		} while((time += Time.deltaTime) < m_Duration);


		m_IsAttacking = false;
		m_Animator.SetBool("Attack", m_IsAttacking);
	}
}
