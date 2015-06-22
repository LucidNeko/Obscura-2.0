using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	private PlayerAudio m_audioScript;

	// Use this for initialization
	void Start () {
		m_audioScript = GetComponent<PlayerAudio> ();
	}
	
	public void Die() {
		transform.position = Checkpoint.LastCheckpoint.position;
		StartCoroutine (Ouch (2));
	}

	public IEnumerator Ouch(float duration) {
		float t = 0;
		while(t < 1) {
			t += 0.25f; //speed
			Vector3 scale = transform.localScale;
			scale.y = Mathf.Lerp(1, 0.1f, t);
			transform.localScale = scale;
			yield return null;
		}

		m_audioScript.die ();

		yield return new WaitForSeconds (0.25f);
		
		t = 0;
		while (t < 1) {
			t += 0.1f; //speed
			Vector3 scale = transform.localScale;
			scale.y = Mathf.Lerp(0.1f, 1, t);
			transform.localScale = scale;
			yield return null;
		}
	}
}
