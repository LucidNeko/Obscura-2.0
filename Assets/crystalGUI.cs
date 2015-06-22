using UnityEngine;
using System.Collections;

public class crystalGUI : MonoBehaviour {

	public Texture2D crystalImage;
	float x = 25.0f;
	float y = 25.0f;
	float width = 50.0f;
	float height = 60.0f;
	

	private CrystalPickup cpu;

	// Use this for initialization
	void Start () {
		cpu = GetComponent<CrystalPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnGUI() {
		for (int i = 0; i < cpu.GetCrystalsCollected(); i++) {
			GUI.DrawTexture (new Rect (x+(i*16), y, width, height), crystalImage);
		}
	}

}
 