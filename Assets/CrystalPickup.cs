using UnityEngine;
using System.Collections;

public class CrystalPickup : MonoBehaviour {

	public static int crystalsCollected;


	void Start () {
		crystalsCollected = 0;
	}
	

	void Update () {
	
	}



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			crystalsCollected++;
			this.gameObject.SetActive(false);
		}
	}


	public int GetCrystalsCollected(){
		return crystalsCollected;
	}
}
