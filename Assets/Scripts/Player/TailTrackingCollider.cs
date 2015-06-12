using UnityEngine;
using System.Collections;

public class TailTrackingCollider : MonoBehaviour {

	Transform m_TailBase, m_TailMid, m_TailTip;

	// Use this for initialization
	void Start () {
		m_TailBase = transform;
		m_TailMid = m_TailBase.GetChild (0);
		m_TailTip = m_TailMid.GetChild (0);

		foreach(Transform t in new Transform[]{ m_TailBase, m_TailMid, m_TailTip }) {
			SphereCollider collider = t.gameObject.AddComponent<SphereCollider> ();
			collider.isTrigger = true;
			collider.radius = 0.05f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
