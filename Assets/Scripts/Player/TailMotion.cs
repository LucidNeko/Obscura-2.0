using UnityEngine;
using System.Collections;

public class TailMotion : MonoBehaviour {

	public float m_TailSpeed = 10f;

	public Transform m_Hip;
	public Transform[] m_Tail;

	private Quaternion[] m_RestingRotations;
	private Quaternion[] m_LeftRotations;
	private Quaternion[] m_RightRotations;

	private Animator m_Animator;

	private Quaternion m_OldHipRotation;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();

		m_RestingRotations = new Quaternion[m_Tail.Length];
		m_LeftRotations = new Quaternion[m_Tail.Length];
		m_RightRotations = new Quaternion[m_Tail.Length];

		for (int i = 0; i < m_Tail.Length; i++) {
			m_RestingRotations[i] = m_Tail[i].localRotation;
			m_LeftRotations[i] = m_RestingRotations[i] * Quaternion.Euler(0,40,0);
			m_RightRotations[i] = m_RestingRotations[i] * Quaternion.Euler(0,-40,0);
		}

		m_OldHipRotation = m_Hip.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		float turn = m_Animator.GetFloat ("Turn");
//		Debug.Log(turn);
		
		for (int i = 0; i < m_Tail.Length; i++) {
			if (turn < 0) {
				//left
				m_Tail [i].localRotation = Quaternion.Slerp(m_Tail [i].localRotation, m_LeftRotations [i], Time.deltaTime * m_TailSpeed);
			} else if (turn > 0) {
				//right
				m_Tail [i].localRotation = Quaternion.Slerp(m_Tail [i].localRotation, m_RightRotations [i], Time.deltaTime * m_TailSpeed);
			} else {

				m_Tail [i].localRotation = Quaternion.Slerp(m_Tail [i].localRotation, m_RestingRotations [i], Time.deltaTime * m_TailSpeed);
			}
		}
	}

	void OnAnimatorMove() {

//		Debug.Log (m_Animator.deltaRotation);


//		Vector3 right = m_Tail [0].TransformDirection (Vector3.right);
//
//		if (turn != 0) {
//			m_Tail[0].localPosition = Vector3.Lerp(m_Tail[0].localPosition, m_RestingPositions[0] + (turn<0? -right:right)*2, Mathf.Abs(turn));
//		}
			 
	}
}
