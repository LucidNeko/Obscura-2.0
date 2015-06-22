using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightingTransition : MonoBehaviour {

	public Material m_Skybox1, m_Skybox2;

	public void Activate() {
		RenderSettings.skybox = RenderSettings.skybox == m_Skybox1 ? m_Skybox2 : m_Skybox1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N)) {
			Activate ();
		}
	}
}
