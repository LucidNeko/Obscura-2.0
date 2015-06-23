using UnityEngine;
using System.Collections;

public class crystalGUI : MonoBehaviour {

	public Texture2D crystalImage;
	float x = 25.0f;
	float y = 25.0f;
	float width = 50.0f;
	float height = 60.0f;
	

	private CrystalPickup cpu;

	public GUIStyle skin;

	// Use this for initialization
	void Start () {
		cpu = GetComponent<CrystalPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnGUI() {

		int quantity = CrystalPickup.crystalsCollected;// cpu.GetCrystalsCollected ();

		GUI.DrawTexture (new Rect (x, y, width, height), crystalImage);

		GUI.Label (new Rect (x * 3, y*2, width, height), quantity.ToString(),skin);


			

	}

}
 