using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PlayerController))]
public class PlayerMovement : MonoBehaviour {

	private static Vector3 XZ_PLANE = new Vector3(1, 0, 1);

	private PlayerController m_Controller;
	private Transform m_Camera;

	// Use this for initialization
	void Start() {
		m_Camera = Camera.main.transform;
		m_Controller = GetComponent<PlayerController>();
	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool jump = Input.GetButton("Jump");

		Vector3 forward = Vector3.Scale(m_Camera.forward, XZ_PLANE).normalized;
		Vector3 move = v * forward + h * m_Camera.right;
//		move.Normalize ();

		m_Controller.Move(move, jump);
	}
}
