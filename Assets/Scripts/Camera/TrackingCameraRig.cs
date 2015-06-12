using UnityEngine;
using System.Collections;

public class TrackingCameraRig : MonoBehaviour {

	public Transform m_Target;
	[Range(0, 30)] public float m_MinTilt = 0f;
	[Range(30, 60)] public float m_MaxTilt = 45f;
	public float m_ZoomSpeed = 5f;
	public float m_TrackingSpeed = 10f;
	public float m_YawSpeed = 20f;
	public float m_PitchSpeed = 30f;
	public float m_RotationSpeed = 4f;

	private Transform m_Camera;
	private Transform m_Pivot;
	private float m_DefaultPitch;
	private float m_DefaultDistance;

	private Vector3 m_OldPos, m_OldTargetPos;

	// Use this for initialization
	void Awake () {
		if (m_Target == null) {
			m_Target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		m_Camera = GetComponentInChildren<Camera>().transform;
		m_Pivot = m_Camera.parent;
		m_DefaultPitch = m_Pivot.eulerAngles.x;
		m_DefaultDistance = m_Camera.localPosition.z;

		m_OldPos = transform.position;
		m_OldTargetPos = m_Target.position;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.F)) {
			Camera.main.GetComponent<CameraControls>().Shake(5, 0.5f);
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float camJoyX = Input.GetAxis ("Joy X");
		float camJoyY = Input.GetAxis ("Joy Y");

		HandlePosition ();
		HandleOrientation (horizontal, camJoyX, camJoyY, true, false);
		HandleCameraClipping();
	}

	private void HandlePosition() {
		//set rig base to be targets position

		float t = Time.time; //first time is 0, so hacky ternary fix..
		transform.position = SuperSmoothLerp (m_OldPos, m_OldTargetPos, m_Target.position, (t!=0?t:0.01f), m_TrackingSpeed);

	     m_OldPos = transform.position;
	     m_OldTargetPos = m_Target.position;
	}

	private void HandleOrientation(float horizontal, float camJoyX, float camJoyY, bool invertX, bool invertY) {
		camJoyX -= horizontal/2f; // pivot around camera when walking sideways // divide 2 is based on how far camera is away

		//invert if required
		camJoyX = invertX ? -camJoyX : camJoyX;
		camJoyY = invertY ? -camJoyY : camJoyY;

		//calculate pitch. if no camJoyY input resets pitch to default pitch.
		float pitch = camJoyY == 0 ? m_DefaultPitch : m_Pivot.eulerAngles.x + camJoyY * m_PitchSpeed;
		pitch = Mathf.Clamp (pitch, m_MinTilt, m_MaxTilt);

		//calculate yaw based on camJoyX
		float yaw = m_Pivot.eulerAngles.y + camJoyX * m_YawSpeed;

		//interpolate to the new orientation
		Quaternion newRotation = Quaternion.Euler (pitch, yaw, 0f);
		m_Pivot.rotation = Quaternion.Slerp(m_Pivot.rotation, newRotation, Time.deltaTime * m_RotationSpeed);
	}


	//shoots a ray from pivot to camera. sets the cameras z offset based on how far along the ray it managed to travel.
	private void HandleCameraClipping() {
		int layerMask = LayerMask.GetMask ("Camera Collision");
		float radius = 0.2f;

		RaycastHit info;
		if (Physics.SphereCast (m_Pivot.position, radius, (m_Camera.position - m_Pivot.position).normalized, out info, -m_DefaultDistance, layerMask)) {
			Vector3 point = info.point + info.normal*radius; //0.2f!! as in spherecast.

			float length = Vector3.Magnitude(m_Pivot.position - point) - radius;

			Vector3 p = m_Camera.localPosition;
			p.z = Mathf.Lerp(p.z, Mathf.Min(-1, -length), Time.deltaTime * m_ZoomSpeed);
			m_Camera.localPosition = p;

//			Debug.DrawLine(m_Pivot.position, info.point, Color.black);
//			Debug.DrawLine(info.point, info.point + info.normal*2, Color.blue);
//			Debug.DrawLine(m_Pivot.position, point, Color.green);
//			Debug.DrawLine(_pivot.position, _pivot.position + dir*info.distance, Color.black);
//			Debug.Log ("hit");
		} else {
			Vector3 pos = m_Camera.localPosition;
			pos.z = Mathf.Lerp(pos.z, m_DefaultDistance, Time.deltaTime * m_ZoomSpeed);
			m_Camera.localPosition = pos;
//			Debug.Log ("no-hit");
//			Debug.DrawLine(m_Pivot.position, m_Camera.position);
		}


	}

	/** 
	 * Super Smooth Lerp code from:
	 * http://forum.unity3d.com/threads/how-to-smooth-damp-towards-a-moving-target-without-causing-jitter-in-the-movement.130920/
	 */
	private Vector3 SuperSmoothLerp(Vector3 x0, Vector3 y0, Vector3 yt, float t, float k) {
		Vector3 f = x0 - y0 + (yt - y0) / (k * t);
		return yt - (yt - y0) / (k*t) + f * Mathf.Exp(-k*t);
	}
}
