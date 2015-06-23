using UnityEngine;
using System.Collections;

public class BigCrystal : MonoBehaviour {



	public GameObject crysM;
	private CrystalPickup cp;

	public UIMessageScript ms;


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
			if(quantity<5){
				ms.setMessageNum(0);
			}
			else{
				ms.setMessageNum(1);
			}
		}
	}

	public IEnumerator EnoughCrystals(){
		yield return null;
	}



}
