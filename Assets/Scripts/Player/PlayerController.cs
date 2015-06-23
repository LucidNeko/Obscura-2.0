using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

	public float m_RotationSpeed = 10f;
	public float m_AirMoveSpeed = 1f;
	public float m_JumpForce = 10f;
	public float m_GravityMultiplier = 4f;
	public float m_GroundRayLength = 0.2f;
	public PlayerAudio m_audioScript;

	private Rigidbody m_Body;
	private Animator m_Anim;

	private bool m_IsGrounded; 
	private Vector3 m_GroundNormal;

	private float m_TurnAmount;
	private float m_ForwardAmount;

	private Vector3 m_LastGround;
	private Vector3 m_FallingVelocity = Vector3.zero;

	private PlayerControls m_PlayerControls;

	// Use this for initialization
	void Start() {
		m_Body = GetComponent<Rigidbody>();
		m_Anim = GetComponent<Animator>();

		m_PlayerControls = GetComponent<PlayerControls> ();

		//freeze rigidbody rotation
		m_Body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	
	public void Move(Vector3 move, bool jump) {
		CheckOnGround ();
		
		//If we are actually moving
		if (move != Vector3.zero) {
			//look in direction of move
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (move), Time.deltaTime * m_RotationSpeed);
			//covert global/camera move vector into local space
			move = transform.InverseTransformDirection (move);

			//project on a plane so that we walk slower up slopes.
			move = Vector3.ProjectOnPlane (move, m_GroundNormal);

			//angle between x and z
			m_TurnAmount = Mathf.Atan2 (move.x, move.z);

			//if we are on flat ground it will be 1, if on a upwards slop it will be < 1. creating a slower move up slopes
			m_ForwardAmount = move.z;

//			_body.MovePosition (transform.position + transform.forward * _forwardAmount * moveSpeed * Time.deltaTime);
			if(!m_IsGrounded) {
				m_Body.MovePosition (Vector3.Lerp(m_Body.position, m_Body.position + m_Body.transform.forward * m_ForwardAmount * m_AirMoveSpeed, Time.deltaTime));
			}
		} else {
			//reset animator properties
			m_TurnAmount = 0f;
			m_ForwardAmount = 0f;
		}

		if (m_IsGrounded) {
			HandleJump(jump);
		} else {
			FallFaster();
			FallBackToEarth ();
		}


		UpdateAnimatorProperties();
	}

	private void CheckOnGround() {

		if (Mathf.Abs(m_Body.velocity.y) < 0.01f) {
			m_GroundNormal = Vector3.up;
			m_IsGrounded = true;
			return;
		}

		RaycastHit info;
		if(Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out info, m_GroundRayLength)) {
			if(m_IsGrounded == false) {
				m_LastGround = transform.position;
			}

			if(m_FallingVelocity.y < -50) {
				m_FallingVelocity = Vector3.zero;
			}

			m_GroundNormal = info.normal;
			m_IsGrounded = true;
		} else {
			m_FallingVelocity = m_Body.velocity;
			m_GroundNormal = Vector3.up;
			m_IsGrounded = false;
		}
	}

	private void FallFaster() {
		//Add additional gravitational force
		//subtract gravity, so that a 2x multiplier just ads on one mroe lot of gravity.
		if (!m_Anim.GetBool ("Attack") || m_Body.velocity.y > 0) { //less gravity during attack, only when falling while attacking
			m_Body.AddForce ((Physics.gravity * m_GravityMultiplier) - Physics.gravity); 
		}
	}

	private void HandleJump(bool jump) {
		if (jump && m_IsGrounded && !m_Anim.IsInTransition(m_Anim.GetLayerIndex("Base Layer")) && !m_Anim.GetCurrentAnimatorStateInfo(m_Anim.GetLayerIndex("Base Layer")).IsName("Jump")) {
			m_audioScript.jump(); // Play jump audio
			m_Body.velocity = new Vector3(0, m_JumpForce, 0);
			m_IsGrounded = false;
		}
	}

	private void UpdateAnimatorProperties() {
		m_Anim.SetFloat ("Speed", Mathf.Abs (m_ForwardAmount));
		m_Anim.SetFloat("Direction", m_ForwardAmount < 0 ? -1f : m_ForwardAmount > 0 ? 1f : 0f);
		m_Anim.SetFloat ("Turn", m_TurnAmount);
		m_Anim.SetBool("OnGround", m_IsGrounded);
		if (!m_IsGrounded) {
			m_Anim.SetFloat ("Jump", m_Body.velocity.y);
		} else {
			m_Anim.SetFloat ("Jump", 0f);
		}
	}

	private void FallBackToEarth() {
		if (transform.position.y < -50) {
//			m_Body.MovePosition(m_LastGround + Vector3.up*30);
			m_PlayerControls.Die();
			m_Body.velocity = Vector3.Scale(m_Body.velocity, new Vector3(0, 1, 0));
		}
	}

	//Root motion

	public void OnAnimatorMove() {


//		if (_anim.GetCurrentAnimatorStateInfo (_anim.GetLayerIndex ("Base Layer")).IsName ("Rush")) {
//
//		}

		if (m_IsGrounded && !m_Anim.GetBool("Attack")) {
			Vector3 velocity = m_Anim.deltaPosition / Time.deltaTime;
			velocity.y = m_Body.velocity.y;

//			if(m_Anim.GetBool("Attack")) {
//				velocity.x += m_Body.velocity.x;
//				velocity.z += m_Body.velocity.z;
//			}

			m_Body.velocity = velocity;
		}

//		Vector3 v0 = _body.velocity;
//		Vector3 v1 = _anim.deltaPosition / Time.deltaTime;



	}
}
