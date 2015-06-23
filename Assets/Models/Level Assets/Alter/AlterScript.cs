using UnityEngine;
using System.Collections;

public class AlterScript : MonoBehaviour {

	//Light
	public Light m_Light;

	//Rendersettings
	public Material m_SkyboxA;
	public Color m_FogColourA;
	public float m_FogDensityA;

	public Material m_SkyboxB;
	public Color m_FogColourB;
	public float m_FogDensityB;

	//Lighting
	public Color m_LightColourA;
	public Color m_LightColourB;

	//Dark World Particles
	public GameObject m_DarkWorldParticles;

	private Animator m_Animator;

	enum State { A, B };

	private State state = State.A;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool CanActivate() {
		return m_Animator.GetCurrentAnimatorStateInfo (0).IsName ("None");
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") && CanActivate()) {
			m_Animator.SetTrigger("Activate");
			Camera.main.GetComponent<CameraControls>().Shake(1f, 4f);
			Camera.main.GetComponent<CameraControls>().LookAt(Vector3.zero/*transform.position*/, 3, 3f);

			StartCoroutine(TransitionEnvironment(2.5f));
			TransitionObjects(); 
		}
	}

	public IEnumerator TransitionEnvironment(float speed) {
		float time = 0;
		do {
			Material skybox;
			switch(state) {
			case State.A :
				RenderSettings.fogColor = Color.Lerp(m_FogColourA, m_FogColourB, time);
				RenderSettings.fogDensity = Mathf.Lerp(m_FogDensityA, m_FogDensityB, time);
				m_Light.color = Color.Lerp(m_LightColourA, m_LightColourB, time);
				break;
			case State.B :
				RenderSettings.fogColor = Color.Lerp(m_FogColourB, m_FogColourA, time);
				RenderSettings.fogDensity = Mathf.Lerp(m_FogDensityB, m_FogDensityA, time);
				m_Light.color = Color.Lerp(m_LightColourB, m_LightColourA, time);
				break;
			}
//			DynamicGI.UpdateEnvironment();
			yield return null;
		} while((time += speed*Time.deltaTime) < 1);

		RenderSettings.skybox = (state == State.A) ? m_SkyboxB : m_SkyboxA;
		RenderSettings.fogColor = (state == State.A) ? m_FogColourB : m_FogColourA;
		RenderSettings.fogDensity = (state == State.A) ? m_FogDensityB : m_FogDensityA;
		m_Light.color = (state == State.A) ? m_LightColourB : m_LightColourA;

		state = (state == State.A) ? State.B : State.A;

		if (state == State.A) {
			m_DarkWorldParticles.SetActive (false);
		} else {
			m_DarkWorldParticles.SetActive (true);
		}
	}

	public void TransitionObjects() {
		foreach (GameObject obj in TransitionableObject.GetAll) {
			obj.GetComponent<Animator>().SetTrigger("Activate");
		}
	}
}
