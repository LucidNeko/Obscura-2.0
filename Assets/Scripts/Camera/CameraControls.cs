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

	public void LookAt(Transform target, float height, float duration) {
		StartCoroutine(LookAtCoroutine(target, height, duration));
	}

	public IEnumerator LookAtCoroutine(Transform target, float height, float duration) {
		Quaternion firstRotation = transform.localRotation;
		Vector3 firstPosition = transform.localPosition;

		m_Rig.enabled = false;
		float time = 0f;
		do {
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up*height, 0.05f);
			
			Quaternion oldRotation = transform.rotation;
			transform.LookAt (target.position);
			Quaternion rotationTarget = transform.rotation;
			transform.rotation = oldRotation;
			
			transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, 0.05f);
			yield return null;
		} while((time += Time.deltaTime) < duration);

		m_Rig.enabled = true;

		time = 0f;
		do {
			transform.localPosition = Vector3.Lerp(transform.localPosition, firstPosition, 0.1f);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, firstRotation, 0.1f);
			yield return null;
		} while((time += Time.deltaTime) < duration/2f);
		
		transform.localPosition = firstPosition;
		transform.localRotation = firstRotation;


	}


}
