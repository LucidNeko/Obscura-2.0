using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	private Vector3 m_DefaultPosition;
	private TrackingCameraRig m_Rig;

	public void Awake() {
		m_DefaultPosition = transform.localPosition;
		m_Rig = transform.parent.parent.GetComponent<TrackingCameraRig> ();
	}

	public void Shake(float intensity, float duration) {
		StartCoroutine (ShakeCoroutine(intensity, duration));
	}

	public IEnumerator ShakeCoroutine(float intensity, float duration) {
		float time = 0f;
		while(time < duration) {
			time += Time.deltaTime;
			Vector3 offset = SmoothRandom.GetVector3 (intensity).normalized;
			offset.Scale(new Vector3(Random.Range(0f, 1f) < 0.5f ? 1 : -1, 
			                         Random.Range(0f, 1f) < 0.5f ? 1 : -1, 
			                         Random.Range(0f, 1f) < 0.5f ? 1 : -1));
			transform.localPosition = Vector3.Lerp(transform.localPosition, m_DefaultPosition + offset, Time.deltaTime * intensity*1.5f);
			yield return null;
		}
		transform.localPosition = m_DefaultPosition;
	}

	public void LookAt(Transform target, float duration) {
		StartCoroutine(LookAtCoroutine(target, duration));
	}

	public IEnumerator LookAtCoroutine(Transform target, float duration) {
//		Transform oldTarget = m_Rig.m_Target;
//		m_Rig.m_Target = target;
//		yield return new WaitForSeconds (duration);
//		m_Rig.m_Target = oldTarget;
//		Quaternion oldRotation = transform.rotation;
//		transform.LookAt (target.position);
//		Quaternion rotationTarget = transform.rotation;
//		transform.rotation = oldRotation;
		Quaternion firstRotation = transform.rotation;
		Vector3 firstPosition = transform.position;
		m_Rig.enabled = false;
		float time = 0f;
		do {
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up*0.5f, 0.05f);

			Quaternion oldRotation = transform.rotation;
			transform.LookAt (target.position);
			Quaternion rotationTarget = transform.rotation;
			transform.rotation = oldRotation;

			transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, 0.05f);
//			transform.LookAt(target.position);
			yield return null;
		} while((time += Time.deltaTime) < duration);
		transform.position = firstPosition;
		transform.rotation = firstRotation;
		m_Rig.enabled = true;


	}


}
