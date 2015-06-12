using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class BoneTrackingCollider : MonoBehaviour {

	private SphereCollider m_Collider;

	// Use this for initialization
	void Start () {
		m_Collider = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		SphereCollider newCollider = gameObject.AddComponent<SphereCollider> ();
		newCollider.center = m_Collider.center;
		newCollider.radius = m_Collider.radius;
		DestroyImmediate (m_Collider);
		m_Collider = newCollider;
	}
}
