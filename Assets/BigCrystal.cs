using UnityEngine;
using System.Collections;

public class BigCrystal : MonoBehaviour {



	public GameObject crysM;
	private CrystalPickup cp;


	// Use this for initialization
	void Start () {
		cp = crysM.GetComponent<CrystalPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			int quantity = cp.GetCrystalsCollected();
			switch (quantity)
			{
			case 0: 
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				StartCoroutine(EnoughCrystals());
				break;

			}
		}
	}

	public IEnumerator EnoughCrystals(){
		yield return null;
	}



}
